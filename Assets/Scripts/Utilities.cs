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
  
}
