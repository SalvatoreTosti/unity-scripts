using UnityEngine;
using System.Collections;

public class AbilityContoller : MonoBehaviour {

	private float nextCooldownTime;
	[SerializeField]  aSpell spell;

	// Use this for initialization
	void Start () {
		nextCooldownTime = Time.time;
		spell.Initialize (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time <= nextCooldownTime) {
			return; // Ability still on cooldown
		} else if(Input.GetButtonDown("Jump")) {
			Debug.Log ("current time: " + Time.time);
			spell.Trigger ();
			nextCooldownTime = Time.time + spell.cooldown;
			Debug.Log("Next cooldown: "+ nextCooldownTime); 
		}
	}
}
