using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/Health Effect (instant)")]
public class HealthEffect : SpellEffect
{
	public enum HEAL_OR_DAMAGE
	{
		HEAL,
		DAMAGE
	}

	private Stats.STAT_TYPE healthStatType = Stats.STAT_TYPE.CURRENT_HEALTH;
	public HEAL_OR_DAMAGE healOrDamage;
	public Stats.STAT_TYPE modifierStatType;
	public int d2;
	public int d4;
	public int d6;
	public int d8;
	public int d10;
	public int d12;
	public int d20;
	public int d100;
	public int weaponDamageMultiplier = 0;
	public int flatAmount;
	[HideInInspector] public GameObject caster;
	[HideInInspector] public Stats casterStats;
	[HideInInspector] public Stats targetStats;

	public override void Initialize (GameObject cstr, GameObject target)
	{
		caster = cstr;
		casterStats = caster.GetComponent<Stats> ();
		targetStats = target.GetComponent<Stats> ();
	}

	public override IEnumerator Trigger ()
	{
		if (targetStats != null) {
			int totalAmount = GetRollAmount () + GetModifier ();
			Debug.Log ("modifier amount: " + GetModifier ());
			if (totalAmount < 0) {
				totalAmount = 0; //round to zero, negatives will flip health applied
			}
			if (healOrDamage == HEAL_OR_DAMAGE.HEAL) {
				targetStats.Apply (healthStatType, totalAmount); //apply does a += to current value
			} else {
				targetStats.Apply (healthStatType, -totalAmount); //negate health, since apply does a += to current value
			}
			yield return null;
		}
	}

	private int GetRollAmount ()
	{
		return
			DiceUtilities.Flip () * d2 +
			DiceUtilities.RollD4 (d4) +
			DiceUtilities.RollD6 (d6) +
			DiceUtilities.RollD8 (d8) +
			DiceUtilities.RollD10 (d10) +
			DiceUtilities.RollD12 (d12) +
			DiceUtilities.RollD20 (d20) +
			DiceUtilities.RollD100 (d100) +
			GetWeaponDamage() * weaponDamageMultiplier +
			GetModifier() +
			flatAmount;
	}

	private int GetModifier ()
	{
		int modifier = casterStats.GetModifier (modifierStatType);
		return modifier;
	}

	private int GetWeaponDamage(){
		if (ValidWeapon (caster)) {
			return caster.GetComponent<Inventory> ().equippedWeapon.GetComponent<WeaponStats> ().damage;
		} else {
			Debug.Log ("No valid weapon found on:"+ caster.name);
			return 0;
		}
	}

	private bool ValidWeapon(GameObject obj){
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
}
