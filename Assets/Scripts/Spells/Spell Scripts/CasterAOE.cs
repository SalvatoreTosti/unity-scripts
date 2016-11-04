using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Caster Area Of Effect")]
public class CasterAOE : SingleSpell {

	[HideInInspector] public Vector3 location;
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
		Collider[] colliders = Physics.OverlapSphere (location, range);
		foreach (Collider collider in colliders) {
			List<string> targetTagsList = new List<string> (targetTags);
			if(targetTagsList.Contains(collider.tag)){
				Debug.Log ("Target Name: " + collider.name);
				effects.AddRange(applyEffects (caster, collider.gameObject, targetEffects));
			}
		}
		return effects.ToArray();
	}
}
