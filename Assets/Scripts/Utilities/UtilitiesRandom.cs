using UnityEngine;
using System.Collections;

public class UtilitiesRandom {

	public static Vector3 RandomVector3(float lo, float hi){
		float x = Random.Range (lo, hi);
		float y = Random.Range (lo, hi);
		float z = Random.Range (lo, hi);
		return new Vector3 (x, y, z);
	}

	public static Vector3 RandomVector3XY(float lo, float hi){
		float x = Random.Range (lo, hi);
		float y = Random.Range (lo, hi);
		float z = 0.0f;
		return new Vector3 (x, y, z);
	}

	public static Vector3 RandomVector3XY(float lo, float hi, float thirdComponent){
		float x = Random.Range (lo, hi);
		float y = Random.Range (lo, hi);
		float z = thirdComponent;
		return new Vector3 (x, y, z);
	}

	public static Vector3 RandomVector3YZ(float lo, float hi){
		float x = 0.0f;
		float y = Random.Range (lo, hi);
		float z = Random.Range (lo, hi);
		return new Vector3 (x, y, z);
	}

	public static Vector3 RandomVector3YZ(float lo, float hi, float thirdComponent){
		float x = thirdComponent;
		float y = Random.Range (lo, hi);
		float z = Random.Range (lo, hi);
		return new Vector3 (x, y, z);
	}

	public static Vector3 RandomVector3XZ(float lo, float hi){
		float x = Random.Range (lo, hi);
		float y = 0.0f;
		float z = Random.Range (lo, hi);
		return new Vector3 (x, y, z);
	}

	public static Vector3 RandomVector3XZ(float lo, float hi, float thirdComponent){
		float x = Random.Range (lo, hi);
		float y = thirdComponent;
		float z = Random.Range (lo, hi);
		return new Vector3 (x, y, z);
	}



}
