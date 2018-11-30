using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MultiPlayerZombieSpawn : NetworkBehaviour {

	public Enemy enemyPrefab;

	private Enemy enemy = null;

	public QuestGiver questGiverInControl;

	[Tooltip("Manually tell which index in quest giver enemies array this enemy will be in")]
	public int arrayIndex;

	[SerializeField] bool respawnEnabled = false;
	[SerializeField] float spawnTime = 0.0f;

	private float time = 0.0f;

	// Use this for initialization
	void Start () {
		enemy = Instantiate(enemyPrefab, this.transform);
		NetworkServer.Spawn(enemy.gameObject);
		enemy.uiSocket.questGiver = questGiverInControl;
		if (questGiverInControl != null) {
			questGiverInControl.enemies[arrayIndex] = this.enemy;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (respawnEnabled && enemy == null && !questGiverInControl.QuestIsStarted()) {
			time += Time.deltaTime;
			if (time >= spawnTime) {
				enemy = Instantiate(enemyPrefab, this.transform);
				NetworkServer.Spawn(enemy.gameObject);
				enemy.uiSocket.questGiver = questGiverInControl;
				if (questGiverInControl != null) {
					questGiverInControl.enemies[arrayIndex] = this.enemy;
				}
				time = 0;
			}
		}
	}
}
