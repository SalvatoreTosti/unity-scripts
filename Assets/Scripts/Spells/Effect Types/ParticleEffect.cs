using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/Spell Effect/Particle Effect")]
public class ParticleEffect : SpellEffect {

	public float duration;
	public GameObject particle;
	private Transform target;

	public override void Initialize (GameObject obj)
	{
		target = obj.transform;
	}

	public override IEnumerator Trigger ()
	{
		GameObject newParticle = Instantiate (particle);
		newParticle.transform.position = target.position;
		ParticleSystem particleSystem = newParticle.GetComponent<ParticleSystem> ();
		newParticle.GetComponent<MoveTowardSimple> ().target = target;
		if (particleSystem != null) {
			particleSystem.Play ();
			yield return new WaitForSeconds (duration);
			particleSystem.Stop ();
		}
	}
}
