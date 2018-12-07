using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.Networking;

public class CameraFollow : MonoBehaviour {
	private GameObject player;
	//private Quaternion initialCameraPos;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		//initialCameraPos = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	}

	// called once per frame, updating camera after position of player has been updated
	void LateUpdate() {
		UpdateCameraPosition();
		UpdateCameraRotation();
	}

	// Moves camera position to match change in player position, updates playerPos variable
	private void UpdateCameraPosition() {
		this.transform.position = this.player.transform.position;
	}

	// TODO: play around with camera rotation until I find something that works right
	// Rotates camera with arrow keys or right stick of controller
	private void UpdateCameraRotation() {
		transform.RotateAround(this.player.transform.position, Vector3.up, 5.0f * CrossPlatformInputManager.GetAxis("Oculus_GearVR_RThumbstickX"));
		//print("value: " + 5.0f * CrossPlatformInputManager.GetAxis("Vertical Turn"));
		//transform.RotateAround(this.player.transform.position, Vector3.left, 5.0f * CrossPlatformInputManager.GetAxis("Vertical Turn"));
	}
}
