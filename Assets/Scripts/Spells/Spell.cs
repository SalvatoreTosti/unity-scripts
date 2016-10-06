using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spell : MonoBehaviour {


	public string[] targetTags;
	public float cooldown;
	public float castTime;

	public abstract void Cast ();
	public abstract bool Ready();
}
