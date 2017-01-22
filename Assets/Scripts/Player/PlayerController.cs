using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed;
	public float rotationSpeed;
	public GameObject playerFront;

	private Rigidbody rigidBody;
	private Vector3 playerDirection;
	private float playerRotation;
	private float playerMovement;

	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
		
	void FixedUpdate (){
		//Player rotation
		playerRotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
		rigidBody.AddTorque(transform.up * playerRotation);

		//Player movement
		playerDirection = Vector3.Normalize(playerFront.transform.position - transform.position);
		playerMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
		rigidBody.AddForce (playerDirection * playerMovement);
	}
}
