using UnityEngine;
using System.Collections;

public class DrawLineGizmo : MonoBehaviour {

	public Transform target;
	public Color gizmoColor = Color.green;

	void OnDrawGizmos(){
		Gizmos.color = gizmoColor;
		drawLineGizmo ();
	}

	private void drawLineGizmo(){
		if (target != null) {
			Gizmos.DrawLine (transform.position, target.transform.position);
		}
	}
}
