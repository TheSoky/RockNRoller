using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("General Info")]
    public float Speed = 10.0f;
    [SerializeField]
    private float JumpPower = 20.0f;

    private float _moveHorizontal = 0.0f;
	private float _moveVertical = 0.0f;
    private float _jump = 0.0f;

	private Rigidbody _rigidbody;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		CheckForInput ();

	}

	void FixedUpdate()
	{
		Move ();
	}

	void CheckForInput()
	{
		_moveHorizontal = Input.GetAxisRaw ("Horizontal");
		_moveVertical = Input.GetAxisRaw ("Vertical");
    }

    private void OnCollisionStay(Collision collision) {
        if(collision.collider.tag == "Ground") {
            _jump = Input.GetAxisRaw("Jump") * JumpPower;
        }
    }



    void Move()
	{


        Vector3 direction = new Vector3 (_moveHorizontal, _jump, _moveVertical);
		_rigidbody.AddForce (direction * Speed);
        _jump = 0.0f;
	}



}
