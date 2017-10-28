using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    [SerializeField]
    private int SpeedMultiplier = 2;

    private void OnCollisionEnter(Collision other) {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if(playerController != null) {
            playerController.Speed *= SpeedMultiplier;
            LevelManager.LM.Speed *= SpeedMultiplier;
        }
    }
    

}
