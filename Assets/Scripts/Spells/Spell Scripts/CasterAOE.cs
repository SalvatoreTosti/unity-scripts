using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Caster Area Of Effect")]
public class CasterAOE : Spell {

	[HideInInspector] public Vector3 location;
	public float radius;
	[HideInInspector] public GameObject caster;
	public SpellEffect[] targetEffects;
	public SpellEffect[] casterEffects;
	public SpellEffect[] missTargetEffects;
	public SpellEffect[] missCasterEffects;

	public override IEnumerator[] Initialize (GameObject obj)
	{
		caster = obj;
		return null;
	}

	public override IEnumerator[] Trigger ()
	{
		List<IEnumerator> effects = new List<IEnumerator> ();
		effects.AddRange(applyEffects (caster, caster, casterEffects));
		location = caster.transform.position;
		Collider[] colliders = Physics.OverlapSphere (location, radius);
		foreach (Collider collider in colliders) {
			if (collider.tag == "Enemy") {
				effects.AddRange(applyEffects (caster, collider.gameObject, targetEffects));
			}
		}
		return effects.ToArray();
	}
}
