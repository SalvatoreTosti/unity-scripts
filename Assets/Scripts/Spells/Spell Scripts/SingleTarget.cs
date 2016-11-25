using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Single Target")]
public class SingleTarget : SingleSpell
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
		Collider targetCollider = null;
		if (validSpellTarget ()) {
			targetCollider = caster.GetComponent<SpellTarget> ().target.GetComponent<Collider> ();		
		} else {
			Debug.Log ("Invalid target."); 
		}
		if (TargetInRange (targetCollider)) {
			List<string> targetTagsList = new List<string> (targetTags);
			if (targetTagsList.Contains (targetCollider.tag)) {
				effects.AddRange (ApplyEffects (caster, targetCollider.gameObject, enemyEffects));
			}
		} else {
			Debug.Log ("Target, " + targetCollider.name + ", outside of range from Caster, " + caster.name);
			Debug.Log (Vector3.Distance (caster.transform.position, targetCollider.transform.position));
		}
		return effects.ToArray ();
	}

	private bool TargetInRange (Collider targetCollider)
	{
		float distance = Vector3.Distance (caster.transform.position, targetCollider.transform.position);
		return distance < GetSpellRange ();
	}

	private bool attackSuccess ()
	{
		return false;
	}

	private bool validSpellTarget ()
	{
		if (caster == null) {
			return false;
		} else if (caster.GetComponent<SpellTarget> () == null) {
			return false;
		} else if (caster.GetComponent<SpellTarget> ().target == null) {
			return false;
		} else if (caster.GetComponent<SpellTarget> ().target.GetComponent<Collider> () == null) {
			return false;
		} else {
			return true;
		}
	}
}
