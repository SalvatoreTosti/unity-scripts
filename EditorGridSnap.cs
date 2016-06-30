using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class EditorGridSnap : MonoBehaviour {

	void Update () {
		float x = Mathf.Round (transform.position.x);
		float y = Mathf.Round (transform.position.y);
		float z = Mathf.Round (transform.position.z);
		transform.position = new Vector3 (x, y, z);
	}

}


