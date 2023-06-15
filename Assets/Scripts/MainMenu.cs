using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Animator cameraAni;
    private Toggle gyroToggle;
    private Toggle throwToggle;
    public TextMeshProUGUI fidgetCount;
    private TextMeshProUGUI hightScoreText;

    private void Start() {
        cameraAni = GameObject.Find("CameraController").GetComponent<Animator>();
        gyroToggle = GameObject.Find("UsingGyro").GetComponent<Toggle>();
        throwToggle = GameObject.Find("UsingThrow").GetComponent<Toggle>();
        fidgetCount = GameObject.Find("FidgetCount").GetComponent<TextMeshProUGUI>();
        hightScoreText = GameObject.Find("HighScore").GetComponent<TextMeshProUGUI>();
        fidgetCount.text = DataHandeler.fidgets.ToString();

        gyroToggle.isOn = DataHandeler.gyroEnabled;
        throwToggle.isOn = DataHandeler.acceleromiterEnabled;
        hightScoreText.text = "HighScore: " + DataHandeler.hightScore.ToString();

    }

    //Main Menu Buttons
    public void Endless() {
        SceneManager.LoadScene(1);
    }

    public void Other() { 
    
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Skins() {
        cameraAni.SetBool("Skin", true);
    }

    public void Shop() {
        cameraAni.SetBool("Shop", true);
    }

    public void Settings() {
        cameraAni.SetBool("Settings", true);
    }

    public void BackToMenu() {
        cameraAni.SetBool("Skin", false);
        cameraAni.SetBool("Shop", false);
        cameraAni.SetBool("Settings", false);
    }

    //Skin Buttons


    //Shop Buttons


    //settings stuff
    static public void toggleGyro(bool tog) {
        DataHandeler.gyroEnabled = tog;
    }
    static public void toggleThrow(bool togl) {
        DataHandeler.acceleromiterEnabled = togl;
    }
}
