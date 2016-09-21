using UnityEngine;
using System.Collections;

public class DrawSphere : MonoBehaviour {

	public Transform target;
	public float size = 1.0f;
	public Color gizmoColor = Color.green;

	void OnDrawGizmos(){
		Gizmos.color = gizmoColor;
		drawSphereGizmo ();
	}

	private void drawSphereGizmo(){
		if (target != null) {
			Gizmos.DrawWireSphere (target.position,size);
		}
	}
}
