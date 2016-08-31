using UnityEngine;
using System.Collections;

public class Utilites2D : MonoBehaviour
{
	//A place for utilites specific to 2D games

	public static Vector3 getNearestCenter (Vector3 location, float ZDepth)
	{
		float midX = Mathf.Floor (location.x) + 0.5f;
		float midY = Mathf.Ceil (location.y) - 0.5f;
		return new Vector3 (midX, midY, ZDepth);
	}

	public static Vector2 Location2D (Transform tran)
	{
		return new Vector2 (tran.position.x, tran.position.y);
	}

	public static Vector2 Location2D (Vector3 vec)
	{
		return new Vector2 (vec.x, vec.y);
	}

	public static Vector2 Difference (Vector3 vectorA, Vector3 vectorB)
	{
		Vector2 difference = Utilites2D.Location2D (vectorA) - Utilites2D.Location2D (vectorB);
		return difference;
	}

	public static Vector2 Difference (Transform tran, Vector3 vector)
	{
		Vector2 difference = Utilites2D.Location2D (tran) - Utilites2D.Location2D (vector);
		return difference;
	}

	public static Vector2 Difference (Vector3 vector, Transform tran)
	{
		Vector2 difference = Utilites2D.Location2D (vector) - Utilites2D.Location2D (tran);
		return difference;
	}

	public static Vector2 Difference (Transform tranA, Transform tranB)
	{
		Vector2 difference = Utilites2D.Location2D (tranA) - Utilites2D.Location2D (tranB);
		return difference;
	}

    	/* Based on http://answers.unity3d.com/questions/705524/how-do-i-make-an-object-look-at-an-another-object.html */
	public static void LookAt2D (Vector3 dest, Transform tran, float rotationSpeed)
	{
		Vector2 lookDir = Utilites2D.Difference (dest, tran);
		float angle = Mathf.Atan2 (lookDir.y, lookDir.x) * Mathf.Rad2Deg;
		Quaternion quat = Quaternion.AngleAxis (angle, Vector3.forward);
		tran.rotation = Quaternion.Euler (
			Vector3.RotateTowards (
				tran.rotation.eulerAngles, 
				quat.eulerAngles, 
				rotationSpeed * Time.deltaTime, 
				rotationSpeed * Time.deltaTime));
	}
	
	/* Based on http://answers.unity3d.com/questions/705524/how-do-i-make-an-object-look-at-an-another-object.html */
	public static void LookAt2D (Vector3 dest, Transform tran, float rotationSpeed, float rotationOffset)
	{
		Vector2 lookDir = Utilites2D.Difference (dest, tran);
		float angle = Mathf.Atan2 (lookDir.y, lookDir.x) * Mathf.Rad2Deg;
		Quaternion quat = Quaternion.AngleAxis (angle + rotationOffset, Vector3.forward);
		tran.rotation = Quaternion.Euler (
			Vector3.RotateTowards (
				tran.rotation.eulerAngles, 
				quat.eulerAngles, 
				rotationSpeed * Time.deltaTime, 
				rotationSpeed * Time.deltaTime));
	}
}
