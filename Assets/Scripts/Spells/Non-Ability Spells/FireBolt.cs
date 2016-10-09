using UnityEngine;
using System.Collections;

public class FireBolt : Spell {

	public GameObject projectile = (GameObject) Resources.Load("Bolt") as GameObject;

	public FireBolt(){
		castTime = 0.0f;
		cooldown = 1.0f;
	}

	public override void Action(){
		GameObject prj = MonoBehaviour.Instantiate(projectile);
		prj.transform.position = caster.transform.position + Vector3.up + caster.transform.forward;
		prj.GetComponent<Rigidbody> ().AddForce (caster.transform.forward * 1000.0f);
	}

}
