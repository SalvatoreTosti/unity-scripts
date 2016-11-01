using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/Stat Effect")]
public class StatEffect : SpellEffect {

	public float duration;
	public Stats.STAT_TYPE statType;
	public int amount;
	[HideInInspector] public Stats stats;

	public override void Initialize (GameObject obj)
	{
		stats = obj.GetComponent<Stats> ();
	}

	public override IEnumerator Trigger ()
	{
		if (stats != null) {
			stats.Set (statType, amount);
			yield return new WaitForSeconds (duration);
			stats.Set (statType, -amount);
		}
	}
}
