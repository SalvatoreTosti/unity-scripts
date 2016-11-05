using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class XYEditorGridSnap : MonoBehaviour {

	void Update () {
		float x = Mathf.Round (transform.position.x);
		float y = Mathf.Round (transform.position.y);
		float z = transform.position.z;
		transform.position = new Vector3 (x, y, z);
	}
}
