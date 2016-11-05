using UnityEngine;
using System.Collections;

public class MoveToward : MonoBehaviour {

	public Transform target;
	public float speed;
	public float maxDistance;

	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		Debug.Log (Vector3.Distance (transform.position, target.position));
		if (Vector3.Distance (transform.position, target.position) > maxDistance) {
			step = (speed * 2) * Time.deltaTime;
		}

		transform.position = Vector3.MoveTowards (transform.position, target.position, step);


	}
}
