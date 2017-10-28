using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomValue {
    public float Minvalue = 1.0f;
    public float MaxValue = 5.0f;

    public float RandomNumber() {
        return Random.Range(Minvalue, MaxValue);
    }
}