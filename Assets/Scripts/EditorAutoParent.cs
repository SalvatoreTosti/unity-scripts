using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EditorAutoParent : MonoBehaviour {
	public string ParentName;
	// Use this for initialization
	void Start () {
		transform.SetParent (GameObject.Find (ParentName).transform);
	}

}
