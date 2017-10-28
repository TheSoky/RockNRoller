using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private AudioClip BackgroundMusic;
    [SerializeField]
    [Range(0,1)]
    private float BackgroundVolume = 0.5f;
    [SerializeField]
    private AudioClip VictoryMusic;
    [SerializeField]
    [Range(0, 1)]
    private float VictoryVolume = 0.75f;
    [SerializeField]
    private AudioClip DefeatMusic;
    [SerializeField]
    [Range(0, 1)]
    private float DefeatVolume = 1.0f;

    [Header("Read Only")]
    public float Score = 0.0f;
    [SerializeField]
    private float _highscore = 0.0f;
    private AudioSource _audioSource;

    private static GameManager instance = null;
    public static GameManager GM {
        get {
            return instance;
        }
    }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        _audioSource = GetComponent<AudioSource>();
        PlayBackground();
        
    }

    // MUSIC MANAGER
    
    public void PlayBackground() {
        if (!_audioSource.isPlaying) {
            _audioSource.Stop();
            _audioSource.loop = true;
            _audioSource.PlayOneShot(BackgroundMusic, BackgroundVolume);
        }
    }

    public void PlayVictory() {
        _audioSource.loop = false;
        _audioSource.Stop();
        _audioSource.PlayOneShot(VictoryMusic, VictoryVolume);
    }

    public void PlayDefeat() {
        _audioSource.loop = false;
        _audioSource.Stop();
        _audioSource.PlayOneShot(DefeatMusic, DefeatVolume);
    }
    
    //Load/save highscore manager

    public float GetHighScore() {
        LoadHS();
        return _highscore;
    }

    public void CheckAndSaveHighScore() {
        if(Score > _highscore) {
            _highscore = Score;
            SaveHS();
        }

        Score = 0.0f;
    }

    private void SaveHS() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/HighScore.dat");

        PlayerHighScore data = new PlayerHighScore {
            HighScore = _highscore
        };

        bf.Serialize(file, data);
        file.Close();
    }

    private void LoadHS() {
        if (File.Exists(Application.persistentDataPath + "/HighScore.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/HighScore.dat", FileMode.Open);
            PlayerHighScore data = (PlayerHighScore)bf.Deserialize(file);
            file.Close();

            _highscore = data.HighScore;
        }
        else {
            _highscore = 0.0f;
        }
    }

}

[Serializable]
class PlayerHighScore {
    public float HighScore;
}