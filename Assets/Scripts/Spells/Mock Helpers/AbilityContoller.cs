using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilityContoller : MonoBehaviour {

	public Spell spell;
	public Spell[] spellList;

	private int spellListIterator;


	// Use this for initialization
	void Start () {
		spell.nextCooldownTime = Time.time;
		StartTasks (spell.Initialize (this.gameObject));
		foreach (Spell s in spellList) {
			s.nextCooldownTime = Time.time;
			StartTasks (s.Initialize (this.gameObject));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire3")) {
			spell = GetNextSpell(); 
			StartTasks (spell.Initialize (this.gameObject));
		}

		if(Time.time <= spell.nextCooldownTime) {
			return; // Ability still on cooldown
		} else if (Input.GetButtonDown ("Jump")) {
			StartTasks (spell.Trigger ());
			spell.nextCooldownTime = Time.time + spell.cooldown;
		} 
	}

	private Spell GetNextSpell(){
		if (spellListIterator >= spellList.Length) {
			spellListIterator = 0;
		}
		Spell nextSpell = spellList [spellListIterator];
		spellListIterator++;
		return nextSpell;
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
