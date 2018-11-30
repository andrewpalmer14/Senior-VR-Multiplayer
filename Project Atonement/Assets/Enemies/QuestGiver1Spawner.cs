using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver1Spawner : MonoBehaviour {

	public QuestGiver questGiver;


	// Use this for initialization
	void Start () {
		Instantiate(questGiver, this.transform);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
