using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stats : MonoBehaviour
{

	public enum STAT_TYPE
	{
		NONE,
		BASE_HEALTH,
		CURRENT_HEALTH,
		STRENGTH,
		WISDOM,
		CHARISMA,
		MOVEMENT_SPEED
	}

	public class StatList
	{
		private class StatPair
		{
			public STAT_TYPE statType;
			public int statAmount;

			public StatPair (STAT_TYPE type, int amount)
			{
				statType = type;
				statAmount = amount;
			}

		}

		List<StatPair> internalList;

		public StatList(){
			internalList = new List<StatPair>();
		}

		public StatList(Stats stats){
			internalList = new List<StatPair>();
			StatPair baseHealthPair = new StatPair(STAT_TYPE.BASE_HEALTH,stats.baseHealth);
			StatPair currentHealthPair = new StatPair(STAT_TYPE.CURRENT_HEALTH,stats.currentHealth);
			StatPair strengthPair = new StatPair(STAT_TYPE.STRENGTH,stats.strength);
			StatPair wisdomPair = new StatPair(STAT_TYPE.WISDOM,stats.wisdom);

			internalList.Add(baseHealthPair);
			internalList.Add(currentHealthPair);
			internalList.Add(strengthPair);
			internalList.Add(wisdomPair);
		}

		public void SetStat(STAT_TYPE statType, int amount){
			RemoveStat (statType);
			StatPair newPair = new StatPair (statType, amount);
			AddStatPair (newPair);
		}

		public int GetStat(STAT_TYPE statType){
			StatPair pair = GetStatPair (statType);
			if (pair == null) {
				return 0;
			} else {
				return pair.statAmount;
			}
		}

		public void Print(){
			foreach (StatPair pair in internalList) {
				Debug.Log (pair.statType + " : " + pair.statAmount);
			}
		}

		public int Count(){
			return internalList.Count;
		}

		private StatPair GetStatPair(STAT_TYPE statType){
			foreach (StatPair pair in internalList) {
				if (pair.statType == statType) {
					return pair;
				}
			}
			Debug.Log ("No corresponding pair found for type: " + statType);
			return null;
		}

		private void AddStatPair(StatPair newPair){
			internalList.Add (newPair);
		}

		private void RemoveStat(STAT_TYPE statType){
			internalList = FilterStat (internalList, statType);
		}

		private List<StatPair> FilterStat(List<StatPair> list, STAT_TYPE statType){
			List<StatPair> newList = new List<StatPair> ();
			foreach (StatPair pair in list) {
				if (pair.statType != statType) {
					newList.Add (pair);
				}
			}
			return newList;
		}
	}

	public int baseHealth;
	public int currentHealth;

	public int strength;
	public int wisdom;
	public int charisma;
	public int movementSpeed;

	public SpellEffect[] testActiveEffects; //inspector access for pipeable effects
	public List<IPipeableEffect> effectPipeline = new List<IPipeableEffect>();

	void Start(){
	} 

	void Update(){
	}

	private void testCopyEffects(){
		List<IPipeableEffect> pipeables = new List<IPipeableEffect>();
		foreach (SpellEffect effect in testActiveEffects) {
			if (effect is IPipeableEffect) {
				pipeables.Add ((IPipeableEffect) effect);
			}
		}

		foreach (IPipeableEffect pipeable in pipeables) {
			pipeable.PipelineInitialize (null, this.gameObject);
			StartCoroutine(pipeable.PipelineTrigger ());
		}

	}

	private StatList GetCurrentStatList()
	{
		StatList statList = new StatList(this);
		return statList;
	}

	private StatList ApplyPipeline(){
		StatList statList = GetCurrentStatList ();
		foreach(IPipeableEffect effect in effectPipeline){
			effect.Pipe (statList);
		}
		return statList;
	}


	public void adjustBaseHealth (int adjustAmount)
	{
		if (baseHealth + adjustAmount < currentHealth) {			
			baseHealth += adjustAmount;
			currentHealth = baseHealth;
		} else {
			baseHealth += adjustAmount;
		}
	}

	public void Set (STAT_TYPE statType, int amount)
	{
		switch (statType) {
		case STAT_TYPE.CHARISMA:
			charisma = amount;
			break;
		case STAT_TYPE.STRENGTH:
			strength = amount;
			break;
		case STAT_TYPE.WISDOM:
			wisdom = amount;
			break;
		case STAT_TYPE.MOVEMENT_SPEED:
			movementSpeed = amount;
			break;
		}
	}

	public void Apply (STAT_TYPE statType, int amount)
	{
		switch (statType) {
		case STAT_TYPE.BASE_HEALTH:
			baseHealth += amount;
			break;
		case STAT_TYPE.CURRENT_HEALTH:
			currentHealth += amount;
			break;
		case STAT_TYPE.CHARISMA:
			charisma += amount;
			break;
		case STAT_TYPE.STRENGTH:
			strength += amount;
			break;
		case STAT_TYPE.WISDOM:
			wisdom += amount;
			break;
		case STAT_TYPE.MOVEMENT_SPEED:
			movementSpeed += amount;
			break;
		}
	}

	public int GetStat (STAT_TYPE statType)
	{
		switch (statType) {
		case STAT_TYPE.NONE:
			return 0;
		case STAT_TYPE.BASE_HEALTH:
			return (int)baseHealth;
		case STAT_TYPE.CURRENT_HEALTH:
			return (int)currentHealth;
		case STAT_TYPE.CHARISMA:
			return charisma;
		case STAT_TYPE.STRENGTH:
			return strength;
		case STAT_TYPE.WISDOM:
			return wisdom;
		case STAT_TYPE.MOVEMENT_SPEED:
			return movementSpeed;
		}
		Debug.Log ("No STAT_TYPE associated with: " + statType);
		return 0;
	}
	
	public void SetStat (STAT_TYPE statType, int amount)
	{
		//int intAmount = (int)Mathf.RoundToInt (amount);
		switch (statType) {
		case STAT_TYPE.BASE_HEALTH:
			baseHealth = amount;
			return;
		case STAT_TYPE.CURRENT_HEALTH:
			currentHealth = amount;
			return;
		case STAT_TYPE.CHARISMA:
			charisma = amount;
			return;
		case STAT_TYPE.STRENGTH:
			strength = amount;
			return;
		case STAT_TYPE.WISDOM:
			wisdom = amount;
			return;
		}
		Debug.Log ("No STAT_TYPE associated with: " + statType);
	}

	public int GetWeaponModifier ()
	{
		return 5; //stub method
	}

	public int GetModifier (STAT_TYPE statType)
	{
		int baseStat = GetStat (statType);
		int nearestEven = GetEvenFloor (baseStat);
		int remainder;
		if (nearestEven <= 0) {
			Debug.Log ("less than zero: " + nearestEven);
			remainder = 0;
		} else {
			//Debug.Log (nearestEven);
			remainder = nearestEven / 2;
		}

		int modifer = remainder - 5;
		return modifer;

	}

	private int GetEvenFloor (int number)
	{
		if (number % 2 == 1) {
			return number - 1;
		} else {
			return number;
		}
	}


}
