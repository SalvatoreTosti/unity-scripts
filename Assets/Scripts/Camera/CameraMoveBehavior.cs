using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMoveBehavior : MonoBehaviour {

	public Transform defaultTarget;
	public Transform target;

	public float speed;
	public float maxDistance;

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		if (Vector3.Distance (transform.position, target.position) > maxDistance) {
			step = (speed * 2) * Time.deltaTime;
		}

		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
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
}
