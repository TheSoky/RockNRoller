using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour {

    public void LoadLevel(int levelIndex) {
        SceneManager.LoadScene(levelIndex);
        if(levelIndex == 0) {
            GameManager.GM.Score = 0.0f;
        }
    }
}
