using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private float maxHealth = 100.0f;
	private float playerHealth = 100.0f;

	//private int prideLevel = 0;
	//private int wrathLevel = 0;
	//private int slothLevel = 0;
	//private int loveLevel = 0;
	//private int greedLevel = 0;
	//private int gluttonyLevel = 0;

	private int prideXp = 0;
	private int wrathXp = 0;
	private int slothXp = 0;
	private int loveXp = 0;
	private int greedXp = 0;
	private int gluttonyXp = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth < maxHealth) {
			playerHealth += loveXp/100.0f/200.0f;
			if (playerHealth > maxHealth) {
				playerHealth = maxHealth;
			}
		}
	}

	// returns player health
	public float GetPlayerHealth() {
		return playerHealth;
	}

	// returns player max health
	public float GetPlayerMaxHealth() {
		return maxHealth;
	}

	// returns player health as percentage
	public float GetPlayerHealthPercentage() {
		return this.playerHealth/this.maxHealth;
	}

	public void DoDamageToPlayer(float damage) {
		this.playerHealth -= damage;
		if (this.playerHealth <= 0.0f) {
			this.playerHealth = 0.0f;
			//Destroy(this.gameObject);
			Respawn();
		}
		Game.currentGame.playerStats.playerHealth = playerHealth;
		UpdatePosition();
		SaveLoad.Save();
	}

	public void IncreasePride(int xp) {
		prideXp += xp;
		if (prideXp > 10000) {
			prideXp = 10000;
		}
		Game.currentGame.playerStats.prideXp = prideXp;
		UpdatePosition();
		SaveLoad.Save();
	}

	public void IncreaseWrath(int xp) {
		wrathXp += xp;
		if (wrathXp > 10000) {
			wrathXp = 10000;
		}
		Game.currentGame.playerStats.wrathXp = wrathXp;
		UpdatePosition();
		SaveLoad.Save();
	}

	public void IncreaseSloth(int xp) {
		slothXp += xp;
		if (slothXp > 10000) {
			slothXp = 10000;
		}
		Game.currentGame.playerStats.slothXp = slothXp;
		UpdatePosition();
		SaveLoad.Save();
	}

	public void IncreaseLove(int xp) {
		loveXp += xp;
		if (loveXp > 10000) {
			loveXp = 10000;
		}
		Game.currentGame.playerStats.loveXp = loveXp;
		UpdatePosition();
		SaveLoad.Save();
	}

	public void IncreaseGreed(int xp) {
		greedXp += xp;
		if (greedXp > 10000) {
			greedXp = 10000;
		}
		Game.currentGame.playerStats.greedXp = greedXp;
		UpdatePosition();
		SaveLoad.Save();
	}

	public void IncreaseGluttony(int xp) {
		gluttonyXp += xp;
		if (gluttonyXp > 10000) {
			gluttonyXp = 10000;
		}
		Game.currentGame.playerStats.gluttonyXp = gluttonyXp;
		UpdatePosition();
		SaveLoad.Save();
	}

	public int GetPrideLvl() {
		return prideXp/100;
	}

	public int GetWrathLvl() {
		return wrathXp/100;
	}

	public int GetSlothLvl() {
		return slothXp/100;
	}

	public int GetLoveLvl() {
		return loveXp/100;
	}

	public int GetGreedLvl() {
		return greedXp/100;
	}

	public int GetGluttonyLvl() {
		return gluttonyXp/100;
	}

	public void SetPlayerHealth(float playerHealth) {
		this.playerHealth = playerHealth;
	}

	public void SetPlayerMaxHealth(float maxHealth) {
		this.maxHealth = maxHealth;
	}

	private void Respawn() {
		GetComponent<Transform>().position = new Vector3(6f, 0f, -6f);
		this.playerHealth = maxHealth;
	}

	private void UpdatePosition() {
		Game.currentGame.playerStats.gluttonyXp = gluttonyXp;
		Game.currentGame.playerStats.xPos = this.transform.position.x;
		Game.currentGame.playerStats.yPos = this.transform.position.y;
		Game.currentGame.playerStats.zPos = this.transform.position.z;
	}
}
