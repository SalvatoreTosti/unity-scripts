using UnityEngine;
using System.Collections;

[CreateAssetMenu (menuName = "Spells/FireRing")]
public class aFireRing : aSpell {
	
	[HideInInspector] public AOEEffector AOE;
	public float radius;

	public override void Initialize (GameObject obj)
	{
		AOE = obj.GetComponent<AOEEffector> ();
		AOE.radius = radius;
	}

	public override void Trigger ()
	{
		AOE.radius = radius;
		AOE.Effect ();
	}
}
