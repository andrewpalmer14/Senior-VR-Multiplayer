using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCUI : MonoBehaviour {

	[Tooltip ("NPC Canvas Prefab")]
	[SerializeField] GameObject npcCanvasPrefab = null;

	Camera cameraToLookAt;

	// Use this for initialization
	void Start () {
		cameraToLookAt = Camera.main;
		Instantiate(npcCanvasPrefab, transform.position, Quaternion.identity, transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate() {
		if (cameraToLookAt != null) {
			transform.LookAt(cameraToLookAt.transform);
		} else {
			cameraToLookAt = FindObjectOfType<Camera>();
		}
	}
}
