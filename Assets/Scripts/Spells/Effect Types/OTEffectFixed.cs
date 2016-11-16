using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/OT Effect Fixed")]
public class OTEffectFixed : SpellEffect
{

	public float amount;
	public float duration;
	public float delay;
	public bool buff;

	public Stats.STAT_TYPE statType;
	public SpellEffect.EFFECT_TYPE effectType;

	private float tickTime;
	private int tickNumber;
	private float tickAmount;
	private float endAmount;

	[HideInInspector] public Stats stats;

	public override void Initialize (GameObject caster, GameObject target)
	{
		stats = target.GetComponent<Stats> ();
		if (stats != null) {
			if (buff) {
				endAmount = (float) stats.GetStat (statType) + amount;
			} else {
				endAmount = (float) stats.GetStat (statType) - amount;
			}
			endAmount = Mathf.Round (endAmount);

			if (duration == 0) {
				tickNumber = 1;
				tickAmount = amount;
				tickTime = 0;
			} else {
				tickNumber = (int)(30.0f * duration); // base assumption of 30 ticks a second
				tickAmount = amount / tickNumber;
				tickTime = duration / tickNumber;
			}
		}
	}

	public override IEnumerator Trigger ()
	{
		if (stats != null) {
			float currentAmount = (float) stats.GetStat (statType);
			yield return new  WaitForSeconds (delay);
			for (int i = 0; i < tickNumber; i++) {
				if (stats != null) {
					currentAmount = ProtectedAdjustment (buff, currentAmount, endAmount, tickAmount);
					stats.SetStat (statType, (int) currentAmount);
				}
				yield return new WaitForSeconds (tickTime);
			}
			stats.SetStat (statType, (int) endAmount); //final adjustment to remove any remaining small amounts
		}
	}

	public override void Apply (Stats.StatList statList)
	{
		throw new System.NotImplementedException ();
	}

	private float ProtectedAdjustment (bool isBuff, float current, float final, float adjustment)
	{
		if (isBuff) {
			if (current + adjustment > final) {
				return final;
			} else {
				return current + adjustment;
			}
		} else {
			if (current - adjustment < final) {
				return final;
			} else {
				return current - adjustment;
			}
		}
	}
		
}
