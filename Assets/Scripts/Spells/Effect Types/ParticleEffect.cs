using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/Particle Effect")]
public class ParticleEffect : SpellEffect {

	public float duration;
	public GameObject particle;
	private Transform targetTransform;

	public override void Initialize (GameObject caster, GameObject target)
	{
		targetTransform = target.transform;
	}

	public override IEnumerator Trigger ()
	{
		GameObject newParticle = Instantiate (particle);
		newParticle.transform.position = targetTransform.position;
		ParticleSystem particleSystem = newParticle.GetComponent<ParticleSystem> ();
		newParticle.GetComponent<MoveTowardSimple> ().target = targetTransform;
		if (particleSystem != null) {
			particleSystem.Play ();
			yield return new WaitForSeconds (duration);
			particleSystem.Stop ();
		}
	}

	public override void Apply (Stats.StatList statList)
	{
		throw new System.NotImplementedException ();
	}
}
