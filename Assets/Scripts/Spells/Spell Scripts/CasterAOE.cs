using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//[System.Serializable]
[CreateAssetMenu (menuName = "Spells/Caster Area Of Effect")]
public class CasterAOE : SingleSpell
{

	public enum TARGET_TYPE
	{
		TARGET_ALL,
		TARGET_RANDOM
	};

	[HideInInspector] public Vector3 location;
	[HideInInspector] public GameObject caster;

	public SpellEffect[] targetEffects;
	public SpellEffect[] casterEffects;
	public SpellEffect[] missTargetEffects;
	public SpellEffect[] missCasterEffects;

	public TARGET_TYPE targetType;
	public int maxRandomTargets;
	public bool includeCaster; //permit caster to be targeted object

	public override IEnumerator[] Initialize (GameObject obj)
	{
		caster = obj;
		return null;
	}

	public override IEnumerator[] Trigger ()
	{
		List<IEnumerator> effects = new List<IEnumerator> ();
		effects.AddRange (applyEffects (caster, caster, casterEffects));
		location = caster.transform.position;
		Collider[] colliders = Utilities.GetCollidersWithTags (location, range, targetTags);

		if (includeCaster == false) {
			List<Collider> colliderList = new List<Collider> (colliders);
			Collider casterCollider = null;
			foreach (Collider collider in colliderList) {
				if (collider.gameObject == caster) {
					casterCollider = collider;
				}
			}
			colliderList.Remove (casterCollider);
			colliders = colliderList.ToArray ();
		}

		if (targetType == TARGET_TYPE.TARGET_RANDOM) {
			Collider collider = Utilities.GetRandomCollider (colliders);
			effects.AddRange (applyEffects (caster, collider.gameObject, targetEffects));
		} else {
			foreach (Collider collider in colliders) {
				effects.AddRange (applyEffects (caster, collider.gameObject, targetEffects));
			}
		}
		return effects.ToArray();
	}
}
