using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Utilities : MonoBehaviour {
	//A place for general utilities

	public static bool hasTags(Collider collider, string[] tags){
		foreach (string tag in tags) {
			if (collider.tag == tag) {
				return true;
			}
		}
		return false;
	}

	public static bool hasTags(GameObject obj, string[] tags){
		foreach (string tag in tags) {
			if (obj.tag == tag) {
				return true;
			}
		}
		return false;
	}

	public static List<Transform> getDescendentTransforms(Transform parent){
		if (parent == null) {
			return new List<Transform> (); //return empty list if passed null
		}
		List<Transform> transforms = new List<Transform> ();
		foreach (Transform child in parent) {
			transforms.Add (child);
			List<Transform> descendents = getDescendentTransforms (child);
			transforms.AddRange (descendents);
		}
		return transforms;
	}

	public static List<Transform> getDescendentTransforms(GameObject obj){
		if (obj == null) {
			return new List<Transform> (); //return empty list if passed null
		}
		Transform parent = obj.transform;
		return getDescendentTransforms (parent);
	}

	public static List<GameObject> getDescendentObjects(Transform parent){
		if (parent == null) {
			return new List<GameObject> (); //return empty list if passed null
		}
		List<Transform> transformList = getDescendentTransforms (parent);
		List<GameObject> objectList = new List<GameObject> ();
		foreach (Transform t in transformList) {
			objectList.Add (t.gameObject);
		}
		return objectList;
	}

	public static List<GameObject> getDescendentObjects(GameObject obj){
		if (obj == null) {
			return new List<GameObject> (); //return empty list if passed null
		}
		Transform parent = obj.transform;
		return getDescendentObjects (parent);
	}

}
