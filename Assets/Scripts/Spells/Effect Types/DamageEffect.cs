using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/Damage Effect")]
public class DamageEffect : SpellEffect
{
	private Stats.STAT_TYPE healthStatType = Stats.STAT_TYPE.CURRENT_HEALTH;
	public Stats.STAT_TYPE modifierStatType;
	public int d2;
	public int d4;
	public int d6;
	public int d8;
	public int d10;
	public int d12;
	public int d20;
	public int d100;
	public int flatAmount;
	[HideInInspector] public Stats stats;

	public override void Initialize (GameObject obj)
	{
		stats = obj.GetComponent<Stats> ();
	}

	public override IEnumerator Trigger ()
	{
		if (stats != null) {
			int totalDamage = getTotalDamage ();
			stats.Apply (healthStatType, -totalDamage); //negate health, since apply does a += to current value
			yield return null;
		}
	}

	public int getTotalDamage ()
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
		flatAmount;
	}
}
