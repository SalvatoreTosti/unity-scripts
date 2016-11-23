using UnityEngine;
using System.Collections;

public class BehaviorController : MonoBehaviour {

	public enum BEHAVIOR {
		NONE,
		FEAR
	};

	public BEHAVIOR currentBehavior;

	public void Trigger(BEHAVIOR behavior){
		currentBehavior = behavior;
	}
}
