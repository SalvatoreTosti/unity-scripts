using UnityEngine;
using System.Collections;

public class CastSpell : MonoBehaviour {

	public Spell currentSpell;

	void Start(){
		currentSpell = new FireRing ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!currentSpell.Ready ()) {
			return;
		}

		if (Input.GetButton ("Jump")) {
			currentSpell.caster = gameObject;
			currentSpell.target = transform.position;
			StartCoroutine(currentSpell.Cast());
		}
	}
}
