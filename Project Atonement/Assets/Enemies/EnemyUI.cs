using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour {
	[Tooltip("Enemy UI canvas prefab")]
	[SerializeField] GameObject enemyCanvasPrefab = null;
	[SerializeField] GameObject questItemCanvasPrefab = null;
	private GameObject questItemCanvasClone = null;
	public QuestGiver questGiver = null;
	private bool questStarted = false;

	Camera cameraToLookAt;

	// Use this for initialization
	void Start () {
		//cameraToLookAt = Camera.main;
		Instantiate(enemyCanvasPrefab, transform.position, Quaternion.identity, transform);
		if (questItemCanvasPrefab != null) {
			var questItemCanvasPosition = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
			questItemCanvasClone = Instantiate(questItemCanvasPrefab, questItemCanvasPosition, Quaternion.identity, transform);
		}
		if (cameraToLookAt == null) {
			cameraToLookAt = FindObjectOfType<Camera>();
		}
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (cameraToLookAt == null) {
			cameraToLookAt = FindObjectOfType<Camera>();
		}
		if (questGiver != null) {
			if (!questStarted && questGiver.QuestIsStarted()) {
				//Debug.Log("quest started, activating the quest item canvas");
				questItemCanvasClone.SetActive(true);
				questStarted = true;
			}

		}

		if (cameraToLookAt != null) {
			transform.LookAt(cameraToLookAt.transform);
			//transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
		} else {
			cameraToLookAt = FindObjectOfType<Camera>();
		}
	}
}
