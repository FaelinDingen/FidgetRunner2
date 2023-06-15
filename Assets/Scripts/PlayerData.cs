using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour {
    public int fidgetCount;
    private TextMeshProUGUI fidgetText;
    private TextMeshProUGUI distanceText;
    PlayerController playerController;
    Rigidbody rb;
    private GameObject uI;
    private GameObject diedMenu;
    private MeshRenderer meshRenderer;
    public Material defaultMaterial;
    public Material bearingMaterial;

    private void Start() {
        playerController = GetComponent<PlayerController>();
        fidgetText = GameObject.Find("FidgetCount").GetComponent<TextMeshProUGUI>();
        distanceText = GameObject.Find("DistanceScore").GetComponent<TextMeshProUGUI>();
        rb = GetComponent<Rigidbody>();
        uI = GameObject.Find("UI");
        diedMenu = GameObject.Find("DiedMenu");
        meshRenderer = GetComponent<MeshRenderer>();

        diedMenu.SetActive(false);

        Material[] materials = meshRenderer.materials;
        if (!DataHandeler.usingMaterial) {
            materials[0] = defaultMaterial;
            materials[1] = bearingMaterial;
        }
        else {
            if (!DataHandeler.bearingSkinned) {
                materials[0] = DataHandeler.usingMaterial;
                materials[1] = bearingMaterial;
            }
            else {
                materials[0] = DataHandeler.usingMaterial;
                materials[1] = DataHandeler.usingMaterial;
            }
        }
        meshRenderer.materials = materials;
    }

    private void Update() {
        distanceText.text = Mathf.FloorToInt(gameObject.transform.position.x).ToString();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Border")) {
            StartCoroutine(Died());
        }
        else if (other.CompareTag("Figet")) {
            fidgetCount++;
            fidgetText.text = fidgetCount.ToString();
            Destroy(other.transform.gameObject);
            //play sound
        }
    }

    public IEnumerator Died() {
        uI.SetActive(false);
        playerController.speed = 0;
        rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
        rb.AddForce(new Vector3(0, 300, -1000));
        yield return new WaitForSeconds(.86f);
        DataHandeler.fidgets += fidgetCount;
        if (Mathf.FloorToInt(gameObject.transform.position.x) > DataHandeler.hightScore) { 
            DataHandeler.hightScore = Mathf.FloorToInt(gameObject.transform.position.x);
        }
        Time.timeScale = 0;
        diedMenu.SetActive(true);

    }
}
