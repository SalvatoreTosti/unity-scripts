using UnityEngine;
using System.Collections;

public abstract class aSpell : ScriptableObject {

	public float cooldown;
	public float castTime;

	public abstract void Initialize (GameObject obj);

	public abstract void Trigger ();


}
