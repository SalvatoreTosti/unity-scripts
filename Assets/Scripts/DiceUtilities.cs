using UnityEngine;
using System.Collections;

public class DiceUtilities {

	public static int RollDN(int low, int high, int number){

		int totalNumber = 0;
		for (int i = 0; i < number; i++) {
			totalNumber += Random.Range (low, high);
		}
		return totalNumber;
	}

	public static int RollD4(int number){
		return RollDN (1, 4, number);
	}

	public static int RollD6(int number){
		return RollDN (1, 6, number);
	}

	public static int RollD8(int number){
		return RollDN (1, 8, number);
	}

	public static int RollD10(int number){
		return RollDN (0, 9, number);
	}

	public static int RollD12(int number){
		return RollDN (1, 12, number);
	}

	public static int RollD20(int number){
		return RollDN(1, 20, number);
	}

	public static int RollD100(int number){
		return RollDN (1, 100, number);
	}

	public static int Flip(int number){
		return RollDN(0,1, number);
	}

	public static int Flip(){
		return RollDN (0, 1, 1);	
	}

}
