using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
	private Enemy enemy;
	private RawImage healthBarRawImage;

	// Use this for initialization
	void Start () {
		// TODO: debugging needed here, seems like this get component might be finding too many enemies instead of a single enemy
		enemy = GetComponentInParent<Enemy>();
		healthBarRawImage = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
		healthBarRawImage.uvRect = new Rect(-(enemy.GetEnemyHealthPercentage()/2) - 0.5f, 0.0f, 0.5f, 1.0f);
	}
}
