using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EditorGridSnap : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Ceil (transform.position.x);
		float y = Mathf.Ceil (transform.position.y);
		float z = Mathf.Ceil (transform.position.z);
		transform.position = new Vector3 (x, y, z);
	}
}


