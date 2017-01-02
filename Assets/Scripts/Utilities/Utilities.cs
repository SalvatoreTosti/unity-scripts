using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Utilities : MonoBehaviour {
	//A place for general utilities

	public static bool HasTags(Collider collider, string[] tags){
		foreach (string tag in tags) {
			if (collider.tag == tag) {
				return true;
			}
		}
		return false;
	}

	public static bool HasTags(GameObject obj, string[] tags){
		foreach (string tag in tags) {
			if (obj.tag == tag) {
				return true;
			}
		}
		return false;
	}

	public static Collider[] GetCollidersWithTags(Vector3 location, float overlapSize, string[] tags){
		List<Collider> selectedColliders = new List<Collider> ();
		Collider[] colliders = Physics.OverlapSphere (location, overlapSize);
		foreach (Collider collider in colliders) {
			if (HasTags (collider, tags)) {
				selectedColliders.Add (collider);
			}
		}
		return selectedColliders.ToArray ();
	}

	public static Collider NearestCollider(Transform trans, Collider[] colliders){
		if (colliders == null) {
			Debug.Log ("Null collider array passed");
			return null;
		}
		if (colliders.Length == 0) {
			Debug.Log ("Empty collider array passed");
			return null;
		}

		Collider nearest = colliders [0];
		float minDistance = Vector3.Distance (nearest.transform.position, trans.position);
		foreach (Collider collider in colliders) {
			float distance = Vector3.Distance (collider.transform.position, trans.position);
			if (distance < minDistance) {
				nearest = collider;
				minDistance = distance;
			}
		}
		return nearest;
	}

	public static Collider GetRandomCollider(Collider[] colliders){
	if (colliders == null) {
		Debug.Log ("Null collider array passed");
		return null;
	}
	if (colliders.Length == 0) {
		Debug.Log ("Empty collider array passed");
		return null;
	}

	int randomLocation = Random.Range (0, colliders.Length - 1);
	return colliders [randomLocation];
}

	public static List<Transform> GetDescendentTransforms(Transform parent){
		if (parent == null) {
			return new List<Transform> (); //return empty list if passed null
		}
		List<Transform> transforms = new List<Transform> ();
		foreach (Transform child in parent) {
			transforms.Add (child);
			List<Transform> descendents = GetDescendentTransforms (child);
			transforms.AddRange (descendents);
		}
		return transforms;
	}

	public static List<Transform> GetDescendentTransforms(GameObject obj){
		if (obj == null) {
			return new List<Transform> (); //return empty list if passed null
		}
		Transform parent = obj.transform;
		return GetDescendentTransforms (parent);
	}

	public static GameObject[] GetDescendentObjects(Transform parent){
		if (parent == null) {
			return new GameObject[0]; //return empty array if passed null
		}
		List<Transform> transformList = GetDescendentTransforms (parent);
		List<GameObject> objectList = new List<GameObject> ();
		foreach (Transform t in transformList) {
			objectList.Add (t.gameObject);
		}
		return objectList.ToArray();
	}

	public static GameObject[] GetDescendentObjects(GameObject obj){
		if (obj == null) {
			return new GameObject[0]; //return empty array if passed null
		}
		Transform parent = obj.transform;
		return GetDescendentObjects (parent);
	}

	public static void Reactivate(GameObject obj, Vector3 position, Vector3 force){
		obj.transform.position = position;
		obj.SetActive (true);
		Rigidbody rigidBody = obj.GetComponent<Rigidbody> ();
		if (rigidBody != null) {
			rigidBody.AddForce (force);
		} else {
			Debug.Log ("Attempted to apply force to an object without Rigidbody");
		}
	}

	public static void Deactivate(GameObject obj){
		obj.SetActive (false);
	}

}
