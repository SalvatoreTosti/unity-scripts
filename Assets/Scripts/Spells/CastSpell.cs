using UnityEngine;
using System.Collections;

public class CastSpell : MonoBehaviour {

	public Spell currentSpell;

	void Start(){
		currentSpell = new FireBolt ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!currentSpell.Ready ()) {
			return;
		}

		if (Input.GetButton ("Jump")) {
			currentSpell.caster = gameObject;
			StartCoroutine(currentSpell.Cast());
		}
	}
}
