using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class MultiplayerCameraFollow : NetworkBehaviour {
	public GameObject[] players;
	public GameObject player;

	//private Quaternion initialCameraPos;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		//player = GameObject.FindGameObjectWithTag("Player");
		//initialCameraPos = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}

	// called once per frame, updating camera after position of player has been updated
	void LateUpdate() {
		//if (player.GetComponent<NetworkIdentity>().isLocalPlayer) {
			UpdateCameraPosition();
			UpdateCameraRotation();
		//}
	}

	// Moves camera position to match change in player position, updates playerPos variable
	private void UpdateCameraPosition() {
		//if (isLocalPlayer) {
			if (player != null) {
				this.transform.position = this.player.transform.position;
								Debug.Log("player not null");

			} else {
								Debug.Log("player null, searching for player");

				// check to see if it is local player first?
				players = GameObject.FindGameObjectsWithTag("Player");
				foreach (GameObject player in players) {
					if (player.GetComponent<NetworkIdentity>().isLocalPlayer) {
						this.player = player;
						Debug.Log("found player: " + player);
					}
				}
			}
		//}
	}

	// TODO: play around with camera rotation until I find something that works right
	// Rotates camera with arrow keys or right stick of controller
	private void UpdateCameraRotation() {
		//if (isLocalPlayer) {
			if (player != null) {
				transform.RotateAround(this.player.transform.position, Vector3.up, 5.0f * CrossPlatformInputManager.GetAxis("Oculus_GearVR_RThumbstickX"));
			} else {
				//check to see if it is local player first?
				players = GameObject.FindGameObjectsWithTag("Player");
				foreach (GameObject player in players) {
					//if (isLocalPlayer) {
					if (player.GetComponent<NetworkIdentity>().isLocalPlayer) {
						this.player = player;
						Debug.Log("found player: " + player);
					}
				}
			}
			//print("value: " + 5.0f * CrossPlatformInputManager.GetAxis("Vertical Turn"));
			//transform.RotateAround(this.player.transform.position, Vector3.left, 5.0f * CrossPlatformInputManager.GetAxis("Vertical Turn"));
		//}
	}
}