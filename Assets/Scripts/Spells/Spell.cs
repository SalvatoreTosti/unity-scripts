using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spell {


	public string[] targetTags;
	public float cooldown;
	public float castTime;
	public GameObject caster;

	protected bool onCooldown = false;

	public IEnumerator Cast(){
		yield return LeadUp ();
		Action ();
		yield return Cooldown ();
	}

	protected virtual IEnumerator LeadUp (){
		onCooldown = true;
		yield return new WaitForSeconds (castTime);
	}

	protected virtual IEnumerator Cooldown(){
		yield return new WaitForSeconds (cooldown);
		onCooldown = false;
	}

	public abstract void Action ();

	public bool Ready(){
		return !onCooldown;
	}

}
