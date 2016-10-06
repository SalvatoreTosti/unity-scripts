using UnityEngine;
using System.Collections;

public class FireBolt : Spell {

	public GameObject projectile;
	private bool onCooldown;

	// Use this for initialization
	void Start () {
		cooldown = 1.0f;
		castTime = 1.0f;
	}

	private IEnumerator WaitAndCast(){
		onCooldown = true;
		yield return new WaitForSeconds (castTime);
		GameObject prj = Instantiate (projectile);
		prj.transform.position = transform.position + Vector3.up + transform.forward;
		prj.GetComponent<Rigidbody> ().AddForce (transform.forward * 1000.0f);
		yield return new WaitForSeconds (cooldown);
		onCooldown = false;
	}

	public override void Cast(){
		StartCoroutine(WaitAndCast());
	}

	public override bool Ready(){
		return !onCooldown;
	}


}
