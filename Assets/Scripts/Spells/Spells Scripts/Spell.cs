using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Spell : ScriptableObject {

	public float cooldown;
	public float castTime;

	public abstract IEnumerator[] Initialize (GameObject obj);
	public abstract IEnumerator[] Trigger ();

	protected abstract List<IEnumerator> applyCasterEffects(GameObject caster);
	protected abstract List<IEnumerator> applyEnemyEffects(Collider collider);

}
