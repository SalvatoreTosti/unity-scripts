using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Projectile Bolt")]
public class ProjectileBolt : SingleSpell {

	public GameObject projectile;
	public float force;

	public override IEnumerator[] Initialize (GameObject obj)
	{
		caster = obj;
		return null;
	}

	public override IEnumerator[] Trigger ()
	{
		GameObject prj = MonoBehaviour.Instantiate(projectile) as GameObject;
		prj.transform.position = caster.GetComponent<ProjectileSpawn> ().spawn.position;
		prj.GetComponent<Rigidbody> ().AddForce (caster.GetComponent<ProjectileSpawn> ().spawn.forward * force);
		return null;
	}
}
