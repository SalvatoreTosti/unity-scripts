using UnityEngine;
using System.Collections;

public class AbilityContoller : MonoBehaviour {

	private float nextCooldownTime;
	[SerializeField]  Spell spell;

	// Use this for initialization
	void Start () {
		nextCooldownTime = Time.time;
		StartTasks (spell.Initialize (this.gameObject));
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time <= nextCooldownTime) {
			return; // Ability still on cooldown
		} else if(Input.GetButtonDown("Jump")) {
			StartTasks (spell.Trigger ());
			nextCooldownTime = Time.time + spell.cooldown;
		}
	}

	private void StartTasks(IEnumerator[] tasks){
		if (tasks == null) {
			return;
		} else {
			foreach (IEnumerator task in tasks) {
				StartCoroutine (task);
			}
		}
	}
}
