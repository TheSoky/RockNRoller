using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour {

    [SerializeField]

    public int Value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LevelManager.LM.AddCoins(Value);

            Destroy(gameObject);
        }
    }

    private void Awake() {
        
    }

}
