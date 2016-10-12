using UnityEngine;
using System.Collections;

public class AOEEffector : MonoBehaviour {

	[HideInInspector] public Vector3 location;
	[HideInInspector] public float radius;
	public SpellEffect[] EnemyEffects;
	public SpellEffect[] casterEffects;

	public void Effect(){
		applyCasterEffects (this.gameObject);
		location = this.gameObject.transform.position;
		Collider[] colliders = Physics.OverlapSphere (location, radius);
		foreach (Collider collider in colliders) {
			if (collider.tag == "Enemy") {
				applyEnemyEffects (collider);
			}
		}
	}

	private void applyCasterEffects(GameObject caster){
		foreach (SpellEffect effect in casterEffects) {
			SpellEffect effectCopy = ScriptableObject.Instantiate (effect) as SpellEffect;
			effectCopy.Initialize (caster);
			StartCoroutine(effectCopy.Trigger());
		}
	}

	private void applyEnemyEffects(Collider collider){
		foreach (SpellEffect effect in EnemyEffects) {
			SpellEffect effectCopy = ScriptableObject.Instantiate (effect) as SpellEffect;
			effectCopy.Initialize (collider.gameObject);
			StartCoroutine(effectCopy.Trigger());
		}
	}
}
