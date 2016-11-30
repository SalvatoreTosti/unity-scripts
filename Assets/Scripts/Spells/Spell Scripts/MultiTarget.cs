using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Multi Target")]
public class MultiTarget : SingleSpell
{
	public SpellEffect[] enemyEffects;
	public SpellEffect[] casterEffects;

	public override IEnumerator[] Initialize (GameObject obj)
	{
		caster = obj;
		return null;
	}

	public override IEnumerator[] Trigger ()
	{
		List<IEnumerator> effects = new List<IEnumerator> ();
		effects.AddRange (ApplyEffects (caster, caster, casterEffects));
		List<Collider> targetColliders = new List<Collider> ();
		if (!ValidTargets ()) {
			Debug.Log ("Invalid target."); 
		} 
		foreach (GameObject target in caster.GetComponent<SpellTarget> ().targets) {
			if (TargetInRange (target)) {
				List<string> targetTagsList = new List<string> (targetTags);
				if (targetTagsList.Contains (target.tag)) {
					effects.AddRange (ApplyEffects (caster, target, enemyEffects));
				}
			} else {
				Debug.Log ("Target, " + target.name + ", outside of range from Caster, " + caster.name);
				Debug.Log (Vector3.Distance (caster.transform.position, target.transform.position));
			}
		}
		return effects.ToArray ();
	}

	private bool TargetInRange (GameObject target)
	{
		if(target == null){
			return false;
		}
		float distance = Vector3.Distance (caster.transform.position, target.transform.position);
		return distance < GetSpellRange ();
	}

	private bool AttackSuccess ()
	{
		return false;
	}

	private bool ValidSpellTargetScript ()
	{
		if (caster == null) {
			return false;
		} else if (caster.GetComponent<SpellTarget> () == null) {
			return false;
		} else {
			return true;
		}
	}

	private bool ValidTarget (GameObject target)
	{
		if (target.GetComponent<Collider> () == null) {
			return false;
		} else {
			return true;
		}
	}

	private bool ValidTargets ()
	{
		if (!ValidSpellTargetScript ()) {
			return false;
		}
		foreach (GameObject target in caster.GetComponent<SpellTarget> ().targets) {
			if (!ValidTarget (target)) {
				return false;
			}
		}
		return true;
	}
}
