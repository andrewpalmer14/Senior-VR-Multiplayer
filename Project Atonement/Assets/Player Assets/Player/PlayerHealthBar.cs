using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {
	private Player player;
	private RawImage healthBarRawImage;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		healthBarRawImage = GetComponent<RawImage>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = FindObjectOfType<Player>();
		} else {
			healthBarRawImage.uvRect = new Rect(-(player.GetPlayerHealthPercentage()/2) - 0.5f, 0.0f, 0.5f, 1.0f);
		}
	}
}
