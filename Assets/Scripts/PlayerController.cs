using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;
    private bool grounded = true;
    private bool canJump = true;
    public float speed;
    //private float previousAccelerationMagnitude;
    private float accelerationChangeThreshold = 3f; // Adjust this threshold as needed

    [SerializeField] private float actualSpeed;

    void Start() {
        rb = gameObject.GetComponent<Rigidbody>();
        Input.gyro.enabled = true;

    }


    void Update() {
        //groundRaycast
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit, 1.3f)) {
            if (hit.collider.transform.CompareTag("Ground")) {
                grounded = true;
            }
        }
        else {
            grounded = false;
        }
        //jumping
        if (!DataHandeler.acceleromiterEnabled) {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && grounded || Input.GetKeyDown(KeyCode.Space) && grounded && canJump) {
                StartCoroutine(Jump());
            }
        }
        else {
            float currentAccelerationMagnitude = Input.acceleration.magnitude;

            if (currentAccelerationMagnitude > accelerationChangeThreshold && grounded) {
                StartCoroutine(Jump());
            }

            //previousAccelerationMagnitude = currentAccelerationMagnitude;
        }

    }

    private IEnumerator Jump() {
        rb.AddForce(new Vector3(0, 600, 0));
        canJump = false;
        yield return new WaitForSeconds(0.2f);
        canJump = true;
    }

    private void FixedUpdate() {
        if (DataHandeler.gyroEnabled) {
            actualSpeed = Mathf.Clamp(Input.gyro.attitude.x, -.15f, .15f) * -1 * 4 * speed + speed;
        }
        else {
            actualSpeed = speed;
        }
        rb.AddForce(new Vector3(actualSpeed, 0, 0));
    }
}
