using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth = 100;

	public void Apply(float amount){
		currentHealth -= amount;
	}
}
