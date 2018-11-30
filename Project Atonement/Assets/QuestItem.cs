using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour {

	private bool itemFound = false;

	private void OnTriggerEnter(Collider collider) {
		itemFound = true;
		Destroy(this.gameObject);
		//self.gameObject.SetActive(false);
	}

	public bool ItemFound() {
		return itemFound;
	}
}
