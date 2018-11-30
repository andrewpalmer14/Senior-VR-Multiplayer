using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

	[Range (0.0f, 100.0f)]
	[SerializeField] float safeRange = 25.0f;

	[Range (-50.0f, 50.0f)]
	[SerializeField] float xOffset = 0.0f;
	[Range (-50.0f, 50.0f)]
	[SerializeField] float yOffset = 0.0f;
	[Range (-50.0f, 50.0f)]
	[SerializeField] float zOffset = 0.0f;

	private GameObject player;
	private bool targetsAreSetToNull = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (player = null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
		if ((this.transform.position + (new Vector3(xOffset, yOffset, zOffset)) - player.transform.position).magnitude <= safeRange) {
			if (!targetsAreSetToNull) {
				targetsAreSetToNull = true;
				SetEnemiesTarget(null);
			}
		} else {
			if (targetsAreSetToNull) {
				SetEnemiesTarget(player.transform);
			}
			targetsAreSetToNull = false;
		}
	}

	void SetEnemiesTarget(Transform target) {
		Enemy[] enemies = FindObjectsOfType<Enemy>();
		for (int i = 0; i < enemies.Length; i++) {
			enemies[i].SetTarget(target);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(this.transform.position + (new Vector3(xOffset, yOffset, zOffset)), this.safeRange);
	}
}
