using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spell : ScriptableObject {

	public float cooldown;
	public float castTime;
	[HideInInspector] public float nextCooldownTime;

	public abstract IEnumerator[] Initialize (GameObject obj);
	public abstract IEnumerator[] Trigger ();

	protected virtual List<IEnumerator> applyEffects(GameObject caster, GameObject target, SpellEffect[] effects){
		List<IEnumerator> effectEnumerators = new List<IEnumerator> ();
		foreach (SpellEffect effect in effects) {
			SpellEffect effectCopy = ScriptableObject.Instantiate (effect) as SpellEffect;
			effectCopy.Initialize (caster, target);
			effectEnumerators.Add(effectCopy.Trigger());
		}
		return effectEnumerators;
	}
}
