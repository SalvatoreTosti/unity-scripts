using UnityEngine;
using System.Collections;

public abstract class Spell : ScriptableObject {

	public float cooldown;
	public float castTime;
	[HideInInspector] public float nextCooldownTime;
	[HideInInspector] public GameObject caster;

	public abstract IEnumerator[] Initialize (GameObject obj);
	public abstract IEnumerator[] Trigger ();
}
