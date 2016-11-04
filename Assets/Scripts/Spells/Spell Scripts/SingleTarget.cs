using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Single Target")]
public class SingleTarget : SingleSpell {
	[HideInInspector] public GameObject caster;
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
		effects.AddRange(applyEffects (caster, caster, casterEffects));
		Collider collider = null;
		if (validSpellTarget ()) {
			collider = caster.GetComponent<SpellTarget> ().target.GetComponent<Collider> ();		}
		if (collider != null) {
			List<string> targetTagsList = new List<string> (targetTags);
			if(targetTagsList.Contains(collider.tag)){
				effects.AddRange (applyEffects (caster, collider.gameObject, enemyEffects));
			}
		}
		return effects.ToArray();
	}

	private bool attackSuccess(){
		return false;
	}

	private bool validSpellTarget(){
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
