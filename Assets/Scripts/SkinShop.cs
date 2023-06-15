using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinShop : MonoBehaviour {
    private TextMeshProUGUI costText;
    private TextMeshProUGUI buttonText;
    public int price;
    public Material material;
    public Material bearingMaterial;
    public bool bearingSkinned = false;
    public int skinNumber;
    private MainMenu mainMenu;

    private void Start() {
        costText = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        buttonText = gameObject.transform.GetChild(2).GetComponentInChildren<TextMeshProUGUI>();
        mainMenu = GameObject.Find("Canvas").GetComponent<MainMenu>();

        if (!DataHandeler.ownedSkins[skinNumber]) {
            costText.text = price.ToString() + " Figets";
        }
        else {
            costText.text = "Owned";
        }
    }

    private void Update() {
        if (DataHandeler.ownedSkins[skinNumber]) {
            if (DataHandeler.usingMaterial == material) {
                buttonText.text = "Using";
            }
            else {
                buttonText.text = "Equip";
            }
        }
    }

    public void Button() {
        if (DataHandeler.ownedSkins[skinNumber]) {
            DataHandeler.usingMaterial = material;
            DataHandeler.bearingSkinned = bearingSkinned;
        }
        else {
            if (DataHandeler.fidgets - price >= 0) {
                DataHandeler.fidgets -= price;
                mainMenu.fidgetCount.text = DataHandeler.fidgets.ToString();
                DataHandeler.ownedSkins[skinNumber] = true;
                buttonText.text = "Equip";
                DataHandeler.usingMaterial = material;
                DataHandeler.bearingSkinned = bearingSkinned;
            }
        }
    }
}
