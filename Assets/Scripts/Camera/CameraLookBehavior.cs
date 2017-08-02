using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraLookBehavior : MonoBehaviour {

	public enum LookStyle { SMOOTH, LINEAR };

	public float rotationSpeed = 5.0f;
	public LookStyle lookRotation = LookStyle.SMOOTH;

	public Transform defaultTarget;
	public Transform target;

	void Start(){
		target = defaultTarget;
	}

	void Update () {
		if (lookRotation == LookStyle.SMOOTH) {
			smoothLookAt ();
		} else {
			linearLookAt ();
		}
	}

	public void AddTarget(Transform newTarget){
		if (newTarget == null) {
			AddTarget (defaultTarget);
		} else {
			target = newTarget;
		}
	}

	public void RemoveTarget(){
		target = defaultTarget;
	}

	private void smoothLookAt(){
		//http://forum.unity3d.com/threads/smooth-look-at.26141/
		Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
		// Smoothly rotate towards the target point.
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}

	private void linearLookAt(){
		Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
		//Linearly rotate towards the target point.
		transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}

}
