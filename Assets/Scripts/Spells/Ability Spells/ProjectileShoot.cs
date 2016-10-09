using UnityEngine;
using System.Collections;

public class ProjectileShoot : MonoBehaviour {

	public GameObject projectile;
	public Transform spawn;
	[HideInInspector] public float force;

	public void Launch(){
		GameObject prj = MonoBehaviour.Instantiate(projectile) as GameObject;
		prj.transform.position = spawn.position;
		prj.GetComponent<Rigidbody> ().AddForce (spawn.transform.forward * force);
	}
}
