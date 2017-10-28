using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour {

    public float Speed = 10.0f;
    public Vector3 Axis;
    public Transform Target;

	void Update () {
        transform.RotateAround (Target.position, Axis, Speed * Time.deltaTime);
	}
}
