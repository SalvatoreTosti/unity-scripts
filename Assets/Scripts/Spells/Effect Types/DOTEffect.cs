using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/DOT Effect")]
public class DOTEffect : SpellEffect
{
	public float damage;
	public int tickNumber;
	public float tickTime;

	public Health health;

	public override void Initialize (GameObject obj)
	{
		health = obj.GetComponent<Health> ();
	}

	public override IEnumerator Trigger ()
	{
		if (health != null) {
			for (int i = 0; i < tickNumber; i++) {
				if (health != null) {
					health.Apply (damage);
				}
				yield return new WaitForSeconds (tickTime);
			}
		}
	}
}
