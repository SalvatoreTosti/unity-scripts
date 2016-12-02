using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Area Of Effect")]
public class AreaOfEffect : SingleSpell
{

	public enum SPELL_TYPE
	{
		CASTER_AOE,
		TARGET_AOE}

	;

	public enum TARGET_TYPE
	{
		TARGET_ALL,
		TARGET_RANDOM}

	;

	public SPELL_TYPE spellType;

	[HideInInspector] public Vector3 location;
	[HideInInspector] public GameObject target;

	public SpellEffect[] targetEffects;
	public SpellEffect[] casterEffects;
	public SpellEffect[] missTargetEffects;
	public SpellEffect[] missCasterEffects;

	public TARGET_TYPE targetType;
	public int maxRandomTargets;
	public bool includeCaster;
	//permit caster to be targeted object

	public override IEnumerator[] Initialize (GameObject obj)
	{
		caster = obj;
		return null;
	}

	public override IEnumerator[] Trigger ()
	{
		List<IEnumerator> effects = new List<IEnumerator> ();
		effects.AddRange (ApplyEffects (caster, caster, casterEffects));
		if (spellType == SPELL_TYPE.CASTER_AOE) {
			location = caster.transform.position;
		} else {
			location = caster.GetComponent<SpellTarget> ().target.transform.position;
		}
		Collider[] colliders = Utilities.GetCollidersWithTags (location, GetSpellRange (), targetTags);

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
			effects.AddRange (ApplyEffects (caster, collider.gameObject, targetEffects));
		} else {
			foreach (Collider collider in colliders) {
				effects.AddRange (ApplyEffects (caster, collider.gameObject, targetEffects));
			}
		}
		return effects.ToArray ();
	}

	private bool ValidSpellTarget ()
	{
		if (caster == null) {
			return false;
		} else if (caster.GetComponent<SpellTarget> () == null) {
			return false;
		} else if (caster.GetComponent<SpellTarget> ().target == null) {
			return false;
		} else if (caster.GetComponent<SpellTarget> ().target.GetComponent<Collider> () == null) {
			return false;
		} else {
			return true;
		}
	}
}
