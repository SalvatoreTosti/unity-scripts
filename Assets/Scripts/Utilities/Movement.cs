using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float moveSpeed = 1.0f;
	public float rotateSpeed = 1.0f;
	CharacterController controller;

	void Start(){
		controller = GetComponent<CharacterController> ();
	}


	void Update () {
		Vector3 forwardMovement = Input.GetAxis ("Vertical") * transform.forward*moveSpeed;
		controller.Move (forwardMovement);
		Vector3 rotation = Input.GetAxis ("Horizontal") * transform.up * rotateSpeed;
		transform.Rotate (rotation);
	}
}
