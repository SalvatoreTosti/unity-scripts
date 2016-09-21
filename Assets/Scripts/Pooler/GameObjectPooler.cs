using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectPooler : ObjectPooler<GameObject> {

	public GameObject defaultObj;
	public bool instantiateOnEmpty;
	public bool initializeOnStart;

	void Start(){
		if (initializeOnStart && maxSize > 0) {
			for (int i = 0; i < maxSize; i++) {
				GameObject obj = Instantiate (defaultObj);
				PutObject (obj);
			}
		}
	}

	public override void PutObject (GameObject obj)
	{
		if (queue == null) {
			queue = new Queue<GameObject> ();
		}
		if (queue.Count >= maxSize) {
			return;
		} else {
			
			queue.Enqueue (obj);
		}
	}

	protected override GameObject DefaultObject(){
		if (instantiateOnEmpty) {
			return Instantiate (defaultObj);
		} else {
			return null;
		}
	}


}
