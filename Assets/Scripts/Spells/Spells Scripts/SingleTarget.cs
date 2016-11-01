using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Single Target")]
public class SingleTarget : Spell {
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
		effects.AddRange(applyEffects (caster, casterEffects));
		Collider collider = null;
		if (validSpellTarget ()) {
			collider = caster.GetComponent<SpellTarget> ().target.GetComponent<Collider> ();
			Debug.Log ("target name: " + collider.name);
		}
		if (collider != null) {
			if (collider.tag == "Enemy") {
				effects.AddRange (applyEffects (collider.gameObject, enemyEffects));
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
