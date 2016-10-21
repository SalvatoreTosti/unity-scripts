using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{

	public enum STAT_TYPE
	{
		STRENGTH,
		WISDOM,
		CHARISMA
	}

	public int baseHealth;
	public int currentHealth;

	public int strength;
	public int wisdom;
	public int charisma;


	public void adjustBaseHealth (int adjustAmount)
	{
		if (baseHealth + adjustAmount < currentHealth) {			
			baseHealth += adjustAmount;
			currentHealth = baseHealth;
		} else {
			baseHealth += adjustAmount;
		}
	}

	public void Apply (STAT_TYPE statType, int amount)
	{
		switch (statType) {
		case STAT_TYPE.CHARISMA:
			charisma += amount;
			break;
		case STAT_TYPE.STRENGTH:
			strength += amount;
			break;
		case STAT_TYPE.WISDOM:
			wisdom += amount;
			break;
		}
	}
}
