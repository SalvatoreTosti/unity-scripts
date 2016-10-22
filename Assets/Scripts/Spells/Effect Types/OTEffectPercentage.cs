using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/OT Effect Percentage")]
public class OTEffectPercentage : SpellEffect
{
	public float percentage;
	public float duration;
	public float delay;
	public bool heal;

	private float tickTime;
	private int tickNumber;
	private float tickHealthAmount;
	private float endHealthAmount;

	[HideInInspector] public Stats stats;

	public override void Initialize (GameObject obj)
	{
		stats = obj.GetComponent<Stats> ();
		if (stats != null) {
			float healthAmount = stats.baseHealth * percentage;
			if (heal) {
				endHealthAmount = stats.currentHealth + healthAmount;
			} else {
				endHealthAmount = stats.currentHealth - healthAmount;
			}
			if (duration == 0) {
				tickNumber = 1;
				tickHealthAmount = healthAmount;
				tickTime = 0;
			} else {
				tickNumber = (int)(30.0f * duration); // base assumption of 30 ticks a second
				tickHealthAmount = healthAmount / tickNumber;
				tickTime = duration / tickNumber;
			}
		}
	}

	public override IEnumerator Trigger ()
	{
		if (stats != null) {
			for (int i = 0; i < tickNumber; i++) {
				if (stats != null) {
					if (heal) {
						stats.currentHealth += tickHealthAmount;
					} else {
						stats.currentHealth -= tickHealthAmount;
					}
				}
				yield return new WaitForSeconds (tickTime);

			}
			roundingProtection ();
		}

	}

	private void roundingProtection ()
	{
		if (stats == null) {
			return;
		}
		stats.currentHealth = Mathf.Round (stats.currentHealth);
	}
}
