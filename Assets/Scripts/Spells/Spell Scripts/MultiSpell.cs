using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "Spells/Multi Spell")]
public class MultiSpell : Spell {

	public SingleSpell[] spells;

	public override IEnumerator[] Initialize (GameObject obj)
	{
		List<IEnumerator> enumerators = new List<IEnumerator> ();
		foreach(SingleSpell spell in spells){
			enumerators.AddRange(spell.Initialize (obj));
		}
		return enumerators.ToArray();
	}

	public override IEnumerator[] Trigger ()
	{
		List<IEnumerator> enumerators = new List<IEnumerator> ();
		foreach(SingleSpell spell in spells){
			enumerators.AddRange(spell.Trigger());
		}
		return enumerators.ToArray();
	}
}
