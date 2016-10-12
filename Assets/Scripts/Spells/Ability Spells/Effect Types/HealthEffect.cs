using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/SpellEffect/HealthEffect")]
public class HealthEffect : SpellEffect {
	
	public float damage;
	[HideInInspector] public Health health;

	public override void Initialize (GameObject obj)
	{
		health = obj.GetComponent<Health> ();
	}

	public override IEnumerator Trigger ()
	{
		if (health != null) {
			health.Apply (damage);
		}
		yield return null;
	}
}
