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
	
	public void SetStat (STAT_TYPE statType, float amount)
	{
		int intAmount = (int)Mathf.RoundToInt (amount);
		switch (statType) {
		case STAT_TYPE.BASE_HEALTH:
			baseHealth = amount;
			return;
		case STAT_TYPE.CURRENT_HEALTH:
			currentHealth = amount;
			return;
		case STAT_TYPE.CHARISMA:
			charisma = intAmount;
			return;
		case STAT_TYPE.STRENGTH:
			strength = intAmount;
			return;
		case STAT_TYPE.WISDOM:
			wisdom = intAmount;
			return;
		}
		Debug.Log ("No STAT_TYPE associated with: " + statType);
	}
}
