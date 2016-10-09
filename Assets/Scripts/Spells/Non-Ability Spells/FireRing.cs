using UnityEngine;
using System.Collections;

public class FireRing : Spell {

	public float ringSize;

	public FireRing(){
		castTime = 0.0f;
		cooldown = 1.0f;
		ringSize = 5.0f;
	}


	public override void Action(){
		Collider[] colliders = Physics.OverlapSphere (target, ringSize);
		foreach (Collider collider in colliders) {
			Rigidbody rigidbody = collider.GetComponent<Rigidbody> ();
			if (rigidbody != null) {
				Vector3 forceDirection = caster.transform.position + collider.transform.position;
				rigidbody.AddForce (forceDirection * 200.0f);
			}
		}
		//		GameObject prj = MonoBehaviour.Instantiate(projectile);
		//		prj.transform.position = caster.transform.position + Vector3.up + caster.transform.forward;
		//		prj.GetComponent<Rigidbody> ().AddForce (caster.transform.forward * 1000.0f);
	}
}
