using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

    [SerializeField]
    private Transform Target;
    [SerializeField]
    private float Speed = 5.0f;
    [SerializeField]
    private float DistanceToKeep = 0.0f;

    private Rigidbody _rigidbody;
    private float _distanceToTarget;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (Target == null) {
            return;
        }
        transform.LookAt(Target);

        _distanceToTarget = Vector3.Distance(transform.position, Target.position);
        if (_distanceToTarget > DistanceToKeep) {
            _rigidbody.AddForce(transform.forward * Speed);
        }
    }

    public void SetTarget(Transform newTarget) {
        Target = newTarget;
    }
}
