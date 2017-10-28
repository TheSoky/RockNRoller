using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //Level values
    [SerializeField]
    private float StartingTime = 15.0f;
    [SerializeField]
    private int CoinsToWin = 15;
    public int Speed = 1;

    //OtherComponents
    [SerializeField]
    private SphereCollider PlayerCollision;
    [SerializeField]
    private HealthManager PlayerHM;
    [SerializeField]
    private PlayerController PlayerPC;

    //text fields
    [SerializeField]
    private Text CoinsForWinText;
    [SerializeField]
    private Text CoinsText;
    [SerializeField]
    private Text TimerText;
    [SerializeField]
    private Text HPText;
    [SerializeField]
    private Text LivesText;
    [SerializeField]
    private Text SpeedText;
    [SerializeField]
    private Text HighScoreText;
    [SerializeField]
    private Text ScoreText;

    //canvases
    [SerializeField]
    private Canvas GameplayCanvas;
    [SerializeField]
    private Canvas DefeaCanvas;
    [SerializeField]
    private Canvas VictoryCanvas;
    [SerializeField]
    private Canvas EndgameCanvas;

    //other values
    private int Coins = 0;
    private float Timer;
    private bool IsWon = false;

    //singleton var
    private static LevelManager instanceLM = null;
    public static LevelManager LM {
        get {
            return instanceLM;
        }
    }

    private void Awake() {
        if (instanceLM != null && instanceLM != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instanceLM = this;
        }
        Timer = StartingTime;
        CoinsForWinText.text = "Collect " + CoinsToWin + " coins to proceed!";
        GameplayCanvas.enabled = true;
        DefeaCanvas.enabled = false;
        VictoryCanvas.enabled = false;
        EndgameCanvas.enabled = false;
    }

    private void Start() {
        GameManager.GM.PlayBackground();
    }

    private void Update() {
        if (!IsWon) {
            ChangeTimer(-Time.deltaTime);
            LivesText.text = "Lives: " + PlayerHM.GetCurrentLives().ToString();
            HPText.text = "HP: " + PlayerHM.GetCurrentHealth().ToString();
            SpeedText.text = "Speed: x" + Speed.ToString();
        }
    }

    private void ChangeTimer(float time) {
        Timer += time;
        TimerText.text = "Timer: " + Timer.ToString("00.00");
        if(Timer <= 0) {
            GameLost();
        }
    }

    public void AddCoins(int amount) {
        Coins += amount;
        CoinsText.text = "Coins: " + Coins.ToString("00");
        if(Coins >= CoinsToWin) {
            GameWon(Timer);
        }
    }



    public void GameLost() {
        GameManager.GM.PlayDefeat();
        PlayerCollision.enabled = false;
        PlayerPC.enabled = false;
        PlayerHM.enabled = false;
        GameplayCanvas.enabled = false;
        DefeaCanvas.enabled = true;
        VictoryCanvas.enabled = false;
        EndgameCanvas.enabled = false;
    }

    public void GameWon(float timeLeft) {
        GameManager.GM.Score += timeLeft;
        PlayerPC.enabled = false;
        PlayerHM.enabled = false;
        IsWon = true;
        GameManager.GM.PlayVictory();

        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1 ) {
            ScoreText.text = "This Level Score: " + timeLeft.ToString("00.00");
            GameplayCanvas.enabled = false;
            DefeaCanvas.enabled = false;
            VictoryCanvas.enabled = true;
            EndgameCanvas.enabled = false;
        }
        else {
            HighScoreText.text = "Your Score: " + GameManager.GM.Score.ToString("00.00");
            GameplayCanvas.enabled = false;
            DefeaCanvas.enabled = false;
            VictoryCanvas.enabled = false;
            EndgameCanvas.enabled = true;
            GameManager.GM.CheckAndSaveHighScore();
        }

    }
}
