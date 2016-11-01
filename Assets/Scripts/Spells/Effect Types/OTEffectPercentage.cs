using UnityEngine;
using System.Collections;
using UnityEditor;

[CreateAssetMenu (menuName = "Spells/Spell Effect/OT Effect Percentage")]
public class OTEffectPercentage : SpellEffect
{
	[Range (0.0f, 2.0f)] 
	public float percentage;
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

	public override void Initialize (GameObject obj)
	{
		stats = obj.GetComponent<Stats> ();
		if (stats != null) {
			float totalAmount = (float)stats.GetStat (statType) * percentage;
			if (buff) {
				endAmount = (float)stats.GetStat (statType) + totalAmount;
			} else {
				endAmount = (float)stats.GetStat (statType) - totalAmount;
			}
			endAmount = Mathf.Round (endAmount);

			if (duration == 0) {
				tickNumber = 1;
				tickAmount = totalAmount;
				tickTime = 0;
			} else {
				tickNumber = (int) (30.0f * duration); // base assumption of 30 ticks a second
				tickAmount = totalAmount / tickNumber;
				tickTime = duration / tickNumber;
			}
		}
	}

	public override IEnumerator Trigger ()
	{
		if (stats != null) {
			float currentAmount = (float)stats.GetStat (statType);
			yield return new  WaitForSeconds (delay);
			for (int i = 0; i < tickNumber; i++) {
				if (stats != null) {
					currentAmount = ProtectedAdjustment (buff, currentAmount, endAmount, tickAmount);
					stats.SetStat (statType, currentAmount);
				}
				yield return new WaitForSeconds (tickTime);
			}
			stats.SetStat (statType, endAmount); //final adjustment to remove any remaining small amounts
		}
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
