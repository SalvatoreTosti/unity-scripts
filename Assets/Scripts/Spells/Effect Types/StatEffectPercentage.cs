using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/Stat Effect Percentage")]
public class StatEffectPercentage : SpellEffect {

	public float duration;
	public Stats.STAT_TYPE statType;
	public int percentageAmount;
	[HideInInspector] public Stats stats;
	private int originalStatValue;

	public override void Initialize (GameObject caster, GameObject target)
	{
		stats = target.GetComponent<Stats> ();
	}

	public override IEnumerator Trigger ()
	{
		if (stats != null) {
			int originalStatValue = stats.GetStat (statType);
			int newStatValue = originalStatValue * percentageAmount;
			int diff = originalStatValue + newStatValue;
			stats.Set (statType, diff);
			yield return new WaitForSeconds (duration);
			stats.Set (statType, originalStatValue);
		}
	}

//	private int calcPercent(){
//		percentageAmount
//	}
}
