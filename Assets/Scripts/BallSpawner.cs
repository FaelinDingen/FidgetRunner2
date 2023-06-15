using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    private int ballTimer;

    void FixedUpdate()
    {
        if (ballTimer < 0) {
            GameObject baller = Instantiate(ball, gameObject.transform);
            Rigidbody rb = baller.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.right * Random.Range(2000, 5000));
            ballTimer = 120;
        }
        else {
            ballTimer--;
        }
    }
}
