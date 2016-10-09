using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/FireBolt")]
public class aFireBolt : aSpell {

	[HideInInspector] private ProjectileShoot projectileShoot;
	public float force;

	public override void Initialize (GameObject obj)
	{
		projectileShoot = obj.GetComponent<ProjectileShoot> ();
		projectileShoot.force = force;
	}

	public override void Trigger ()
	{
		projectileShoot.force = force;
		projectileShoot.Launch ();
	}

}
