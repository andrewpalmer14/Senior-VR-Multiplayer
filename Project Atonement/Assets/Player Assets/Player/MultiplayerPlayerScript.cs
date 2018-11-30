using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerPlayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Player[] players = FindObjectsOfType<Player>();
		foreach (Player player in players) {
			player.SetPlayerMaxHealth(Game.currentGame.playerStats.maxHealth);
			player.SetPlayerHealth(Game.currentGame.playerStats.playerHealth);
			//player.name = Game.currentGame.playerStats.name;
			player.IncreasePride(Game.currentGame.playerStats.prideXp);
			player.IncreaseWrath(Game.currentGame.playerStats.wrathXp);
			player.IncreaseSloth(Game.currentGame.playerStats.slothXp);
			player.IncreaseLove(Game.currentGame.playerStats.loveXp);
			player.IncreaseGreed(Game.currentGame.playerStats.greedXp);
			player.IncreaseGluttony(Game.currentGame.playerStats.gluttonyXp);
			Enemy[] enemies = FindObjectsOfType<Enemy>();
			foreach (Enemy enemy in enemies) {
				enemy.SetTarget(player.transform);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
