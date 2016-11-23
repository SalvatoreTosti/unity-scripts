using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/Behavior Effect")]
public class BehaviorEffect : SpellEffect {

	public float duration;
	public BehaviorController.BEHAVIOR behavior;

	[HideInInspector] public BehaviorController behaviorController;

	public override void Initialize (GameObject caster, GameObject target)
	{
		behaviorController = target.GetComponent<BehaviorController> ();

	
	}

	public override IEnumerator Trigger ()
	{
		if (behaviorController != null) {
			behaviorController.Trigger(behavior);
			yield return new WaitForSeconds (duration);
			behaviorController.Trigger(BehaviorController.BEHAVIOR.NONE);
		}
		
	}
}
