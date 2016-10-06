using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EditorAutoParent : MonoBehaviour {
	public string ParentName;
	
	void Start () {
		transform.SetParent (GameObject.Find (ParentName).transform);
	}

}
