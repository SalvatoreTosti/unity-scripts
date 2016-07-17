using UnityEngine;
using System.Collections;

public class Utilites2D : MonoBehaviour {
  //A place for utilites specific to 2D games

	public static Vector3 getNearestCenter(Vector3 location, float ZDepth){
		float midX = Mathf.Floor (location.x) + 0.5f;
		float midY = Mathf.Ceil (location.y) - 0.5f;
		return new Vector3 (midX, midY, ZDepth);
	}
}
