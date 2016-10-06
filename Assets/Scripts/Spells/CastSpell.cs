using UnityEngine;
using System.Collections;

public class CastSpell : MonoBehaviour {

	public Spell currentSpell;

	void Start(){
		currentSpell = GetComponent<FireBolt>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!currentSpell.Ready ()) {
			return;
		}

		if (Input.GetButton ("Jump")) {
			GetComponent<FireBolt>().Cast();
		}
	}
}
