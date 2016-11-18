using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu (menuName = "Spells/Spell Effect/Stat Effect")]
public class StatEffect : SpellEffect, IPipeableEffect {

	public float duration;
	public Stats.STAT_TYPE statType;
	public int amount;
	[HideInInspector] public Stats stats;

	public override void Initialize (GameObject caster, GameObject target)
	{
		stats = target.GetComponent<Stats> ();
	}

	public override IEnumerator Trigger ()
	{
		if (stats != null) {
			stats.Apply (statType, amount);
			yield return new WaitForSeconds (duration);
			stats.Apply (statType, -amount);
		}
	}

	public void PipelineInitialize (GameObject caster, GameObject target){
		stats = target.GetComponent<Stats> ();
	}

	public IEnumerator PipelineTrigger(){
		stats.effectPipeline.Add (this);
		yield return new WaitForSeconds (duration);
		stats.effectPipeline.Remove (this);
	}



	public Stats.StatList Pipe(Stats.StatList statList){
		int statAmount = statList.GetStat (statType);
		int newAmount = statAmount + amount;
		statList.SetStat (statType, newAmount);
		return statList;
	}

}
