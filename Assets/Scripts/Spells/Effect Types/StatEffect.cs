using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu (menuName = "Spells/Spell Effect/Stat Effect")]
public class StatEffect : SpellEffect {

	public float duration;
	public Stats.STAT_TYPE statType;
	public int amount;
	[HideInInspector] public Stats stats;

	public override void Initialize (GameObject caster, GameObject obj)
	{
		stats = obj.GetComponent<Stats> ();
	}

	public override IEnumerator Trigger ()
	{
		if (stats != null) {
			stats.Apply (statType, amount);
			yield return new WaitForSeconds (duration);
			stats.Apply (statType, -amount);
		}
	}

	public override void Apply(Stats.StatList statList){
		int statAmount = statList.GetStat (statType);
		int newAmount = statAmount + amount;
		statList.SetStat (statType, newAmount);
	}
}
