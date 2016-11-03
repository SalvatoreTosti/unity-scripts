using UnityEngine;
using System.Collections;

public abstract class SpellEffect : ScriptableObject {

	public enum EFFECT_TYPE
	{
		NONE,
		FIRE,
		ICE,
		POISON
	}

	public abstract void Initialize (GameObject caster, GameObject target);
	public abstract IEnumerator Trigger ();

}
