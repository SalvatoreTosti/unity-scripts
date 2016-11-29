using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OTEffectUtils : MonoBehaviour {

	public class EffectTicker{

		public Queue<int> tickQueue;
		public float tickDuration;

		public EffectTicker(int totalAmount, int seconds){
			int[] ticks = GetTickArray(totalAmount, totalAmount);
			tickDuration = (float) seconds / (float)totalAmount;
			tickQueue = new Queue<int>(ticks);
		}

		public EffectTicker(int totalAmount, int seconds, int ticksPerSecond){
			int[] ticks;

			int absAmount = Mathf.Abs(totalAmount);
			if(absAmount < seconds * ticksPerSecond){
				ticks = GetTickArray(absAmount, totalAmount);
				tickDuration = (float) seconds / (float)totalAmount;
			} else {
				tickDuration = (float) seconds / (float) (seconds * ticksPerSecond);
				ticks = GetTickArray(seconds * ticksPerSecond, totalAmount);
			}
			tickQueue = new Queue<int>(ticks);
		}

		public bool HasNext(){
			return tickQueue.Count > 0;
		}

		public int Next(){
			return (int) tickQueue.Dequeue ();
		}

		/// <summary>
		/// Returns internal tick structure.
		/// For testing ONLY.
		/// </summary>
		/// <returns>Array corresponding to internal queue structure.</returns>
		public int[] DumpTicks(){
			return tickQueue.ToArray ();
		}


		public IEnumerator ApplyTicks(Stats stats, Stats.STAT_TYPE targetStat){
			while (HasNext ()) {
				stats.Apply (targetStat, Next());
				yield return new WaitForSeconds (tickDuration);
			}
		}
			
	}

	/// <summary>
	/// Gets the tick array.
	/// </summary>
	/// <returns>The tick array.</returns>
	/// <param name="tickNumber">Tick number.</param>
	/// <param name="totalDamage">Total damage.</param>
	public static int[] GetTickArray(int tickNumber, int totalDamage){
		if (tickNumber == 0) {
			return new int[0];
		}
		if (totalDamage == 0) {
			return new int[0];
		}
			
		int remainder = GetRemainder(tickNumber,totalDamage);
		int regularTickAmount = GetTickAmount (tickNumber, totalDamage);
		List<int> tickList = new List<int> ();
		for (int i = 0; i < tickNumber; i++) {
			tickList.Add (regularTickAmount);
		}
		tickList.Add (remainder);
		tickList.TrimExcess();
		return tickList.ToArray ();

	}

	/// <summary>
	/// Gets the remainder.
	/// </summary>
	/// <returns>The remainder.</returns>
	/// <param name="tickNumber">Tick number.</param>
	/// <param name="totalDamage">Total damage.</param>
	public static int GetRemainder(int tickNumber, int totalDamage){
		if (tickNumber == 0) {
			return 0;
		}
		return totalDamage % tickNumber;
	}

	/// <summary>
	/// Gets the tick amount.
	/// </summary>
	/// <returns>The tick amount.</returns>
	/// <param name="tickNumber">Tick number.</param>
	/// <param name="totalDamage">Total damage.</param>
	public static int GetTickAmount(int tickNumber, int totalDamage){
		if (tickNumber == 0) {
			return 0;
		}
		return totalDamage / tickNumber;
	}
}
