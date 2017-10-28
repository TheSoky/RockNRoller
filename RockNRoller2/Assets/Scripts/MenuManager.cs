using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private Canvas menuCanvas;

    [SerializeField]
    private Canvas controlCanvas;

    [SerializeField]
    private Text HighScoreText;

    public void Start() {
        ShowMenu();
        GameManager.GM.PlayBackground();
        GameManager.GM.GetHighScore();
        GameManager.GM.CheckAndSaveHighScore();
        HighScoreText.text = ("Highscore: " + GameManager.GM.GetHighScore().ToString("00.00"));
    }

    public void ShowMenu() {
        menuCanvas.enabled = true;
        controlCanvas.enabled = false;
    }

    public void ShowControls() {
        controlCanvas.enabled = true;
        menuCanvas.enabled = false;
    }
}