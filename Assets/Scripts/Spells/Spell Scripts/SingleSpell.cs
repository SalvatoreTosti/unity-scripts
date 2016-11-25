using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class SingleSpell : Spell {
	public bool useWeaponRange;
	public float range;
	public string[] targetTags;

	protected virtual List<IEnumerator> ApplyEffects(GameObject caster, GameObject target, SpellEffect[] effects){
		List<IEnumerator> effectEnumerators = new List<IEnumerator> ();
		foreach (SpellEffect effect in effects) {
			SpellEffect effectCopy = ScriptableObject.Instantiate (effect) as SpellEffect;
			effectCopy.Initialize (caster, target);
			effectEnumerators.Add(effectCopy.Trigger());
		}
		return effectEnumerators;
	}

	protected bool ValidWeapon(GameObject obj){
		Inventory inventory = obj.GetComponent<Inventory>();
		if (inventory == null) {
			return false;
		}

		GameObject weapon = inventory.equippedWeapon;
		if (weapon == null) {
			return false;
		}

		WeaponStats weaponStats = weapon.GetComponent<WeaponStats> ();
		if (weaponStats == null) {
			return false;
		}

		return true;
	}

	protected float GetSpellRange(){
		if (useWeaponRange) {
			if (ValidWeapon (caster)) {
				return caster.GetComponent<Inventory> ().equippedWeapon.GetComponent<WeaponStats> ().range;
			} else {
				Debug.Log ("No valid weapon found on:"+ caster.name);
				return 0.0f;
			}
		} else {
			return range;
		}
		
	}
}
