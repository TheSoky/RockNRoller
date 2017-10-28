using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObjectDestruct : MonoBehaviour {

    public float Timer = 1.0f;

    private void Awake() {
        Invoke("DestroyNow", Timer);
    }

    public void DestroyNow() {
        Destroy(gameObject);
    }
	
}
