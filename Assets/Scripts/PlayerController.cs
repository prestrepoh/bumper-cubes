using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed;
	public float rotationSpeed;

	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
	{
		//Player rotation
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
		rigidBody.AddTorque(transform.up * rotation);
	}
}
