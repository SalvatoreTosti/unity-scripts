using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Poison Ring")]
public class PoisonRing : Spell {

	[HideInInspector] public Vector3 location;
	public float radius;
	[HideInInspector] public GameObject caster;
	public SpellEffect[] EnemyEffects;
	public SpellEffect[] casterEffects;
	
	//[HideInInspector] public AOEEffector AOE;
	//public float radius;

	public override IEnumerator[] Initialize (GameObject obj)
	{
		caster = obj;
		return null;
	}

	public override IEnumerator[] Trigger ()
	{
		List<IEnumerator> effects = new List<IEnumerator> ();
		effects.AddRange(applyCasterEffects (caster));
		location = caster.transform.position;
		Collider[] colliders = Physics.OverlapSphere (location, radius);
		foreach (Collider collider in colliders) {
			if (collider.tag == "Enemy") {
				effects.AddRange(applyEnemyEffects (collider));
			}
		}
		return effects.ToArray();
	}

	protected override List<IEnumerator> applyCasterEffects(GameObject caster){
		List<IEnumerator> effects = new List<IEnumerator> ();
		foreach (SpellEffect effect in casterEffects) {
			SpellEffect effectCopy = ScriptableObject.Instantiate (effect) as SpellEffect;
			effectCopy.Initialize (caster);
			effects.Add(effectCopy.Trigger());
		}
		return effects;
	}

	protected override List<IEnumerator> applyEnemyEffects(Collider collider){
		List<IEnumerator> effects = new List<IEnumerator> ();
		foreach (SpellEffect effect in EnemyEffects) {
			SpellEffect effectCopy = ScriptableObject.Instantiate (effect) as SpellEffect;
			effectCopy.Initialize (collider.gameObject);
			effects.Add(effectCopy.Trigger());
		}
		return effects;
	}
}
