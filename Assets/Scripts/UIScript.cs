using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {
    private GameObject pauzePannel;
    private Animator pauzeAnimator;
    PlayerData playerData;

    private void Start() {
        pauzePannel = GameObject.Find("PauzePannel");
        pauzeAnimator = pauzePannel.GetComponent<Animator>();
        playerData = GameObject.Find("Player").GetComponent<PlayerData>();


        pauzePannel.SetActive(false);
    }

    public void pauze() {
        if (!pauzePannel.activeSelf) {
            Time.timeScale = 0; //maybe make this smooth
            pauzePannel.SetActive(true);
            pauzeAnimator.SetBool("isPauzed", true);
        }
    }

    public void unPauze() {
        Time.timeScale = 1;
        pauzeAnimator.SetBool("isPauzed", false);
    }

    public void QuitGame() {
        Time.timeScale = 1;
        DataHandeler.fidgets += playerData.fidgetCount;
        SceneManager.LoadScene(0);
    }

    public void RetryGame() {
        Time.timeScale = 1;
        DataHandeler.fidgets += playerData.fidgetCount;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
