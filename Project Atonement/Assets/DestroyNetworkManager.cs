using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DestroyNetworkManager : MonoBehaviour {

	// Use this for initialization
	void Start () {		
		Destroy(GameObject.Find("SinglePlayerNetworkManager"));
		Destroy(GameObject.Find("NetworkManager"));
		Destroy(GameObject.Find("SoloMenu"));
	}
}
