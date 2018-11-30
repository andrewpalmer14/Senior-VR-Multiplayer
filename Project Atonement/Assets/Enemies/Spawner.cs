using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] Enemy enemy;
	GameObject player = null;
	[Range (0.0f, 100.0f)]
	[SerializeField] float spawnRange = 5.0f;
	[Range (0.0f, 300.0f)]
	[SerializeField] float instantiateRange = 30.0f;
	[Range (0.0f, 500.0f)]
	[SerializeField] float despawnRange = 50.0f;
	[Range (1, 25)]
	[SerializeField] int maxObjects = 1;
	private List<Enemy> enemies = new List<Enemy>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
		if ((this.transform.position - this.player.transform.position).magnitude >= despawnRange) {
			foreach (Enemy enemy in enemies) {
				Destroy(enemy.gameObject);
			}
			enemies.Clear();
		}
	}

	void FixedUpdate() {
		if ((this.transform.position - this.player.transform.position).magnitude <= instantiateRange) {
			if (enemies.Count < maxObjects) {
				Enemy newEnemy = Instantiate(enemy, this.transform.position + new Vector3(UnityEngine.Random.Range(-spawnRange/2, spawnRange/2), UnityEngine.Random.Range(-spawnRange/2, spawnRange/2), UnityEngine.Random.Range(-spawnRange/2, spawnRange/2)), Quaternion.identity, this.transform);
				newEnemy.SetTarget(this.player.transform);
				newEnemy.SetSpawner(this);
				enemies.Add(newEnemy);
			}
		}
	}

	public void RemoveEnemy(Enemy enemy) {
		enemies.Remove(enemy);
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(this.transform.position, this.spawnRange);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(this.transform.position, this.instantiateRange);

		Gizmos.color = Color.black;
		Gizmos.DrawWireSphere(this.transform.position, this.despawnRange);
	}
		
}
