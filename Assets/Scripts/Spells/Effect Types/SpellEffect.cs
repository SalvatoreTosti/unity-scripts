using UnityEngine;
using System.Collections;

[System.Serializable]
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
