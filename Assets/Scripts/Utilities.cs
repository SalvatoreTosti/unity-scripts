using UnityEngine;
using System.Collections;

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

	private List<Transform> getDescendentTransforms(Transform parent){
		List<Transform> transforms = new List<Transform> ();
		foreach (Transform child in parent) {
			transforms.Add (child);
			List<Transform> descendents = getDescendentTransforms (child);
			transforms.AddRange (descendents);
		}
		return transforms;
	}

	private List<Transform> getDescendentTransforms(GameObject obj){
		Transform parent = obj.transform;
		return getDescendentTransforms (parent);
	}

	private List<GameObject> getDescendentObjects(Transform parent){
		List<Transform> transformList = getDescendentTransforms (parent);
		List<GameObject> objectList = new List<GameObject> ();
		foreach (Transform t in transformList) {
			objectList.Add (t.gameObject);
			}
		return objectList;
	}

	private List<GameObject> getDescendentObjects(GameObject obj){
		Transform parent = obj.transform;
		return getDescendentObjects (parent);
	}

}
