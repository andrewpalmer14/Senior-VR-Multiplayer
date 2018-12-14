using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {

	public static Game currentGame;

	public PlayerStats playerStats;
	//public Character rogue;
	//public Character mage;

	public Game() {
		playerStats = new PlayerStats();
		//rogue = new Character();
		//mage = new Character();
	}
}
