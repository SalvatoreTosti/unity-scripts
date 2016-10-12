using UnityEngine;
using System.Collections;

public abstract class SpellEffect : ScriptableObject {

	public abstract void Initialize (GameObject obj);
	public abstract IEnumerator Trigger ();

}
