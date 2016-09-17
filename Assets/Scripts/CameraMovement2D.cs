using UnityEngine;
using System.Collections;

public class CameraMovement2D : MonoBehaviour
{

	public float speed = 1.0f;

	Vector3 up2D = new Vector3 (0, 1, 0);
	Vector3 down2D = new Vector3 (0, -1, 0);
	Vector3 right2D = new Vector3 (1, 0, 0);
	Vector3 left2D = new Vector3 (-1, 0, 0);

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetAxis ("Vertical") > 0) {
			transform.Translate(up2D * speed);
		}
		if (Input.GetAxis ("Vertical") < 0) {
			transform.Translate (down2D * speed);
		}
		if (Input.GetAxis ("Horizontal") > 0) {
			transform.Translate (right2D * speed);
		}
		if (Input.GetAxis ("Horizontal") < 0) {
			transform.Translate (left2D * speed);

		}

	}

}
