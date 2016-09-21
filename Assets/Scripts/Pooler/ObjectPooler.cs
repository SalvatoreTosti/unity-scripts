using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ObjectPooler<T> : MonoBehaviour {

	public Queue<T> queue;
	public bool populateOnStart;
	public int maxSize;

	public T GetObject(){
		if (queue == null) {
			queue = new Queue<T> ();
		}

		if (queue.Count == 0) {
			return DefaultObject ();
		} else {
			return queue.Dequeue ();
		}
	}

	public virtual void PutObject(T obj){
		if (queue == null) {
			queue = new Queue<T> ();
		}
		queue.Enqueue (obj);
	}

	public int Size(){
		if (queue == null) {
			queue = new Queue<T> ();
		}
		return queue.Count;
	}

	public void Clear(){
		if (queue == null) {
			queue = new Queue<T> ();
		}
		queue.Clear ();
	}

	protected abstract T DefaultObject ();
}
