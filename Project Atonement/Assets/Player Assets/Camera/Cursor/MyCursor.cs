using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursor : MonoBehaviour {
	private CameraRaycaster cameraRaycaster;
	private CursorMode cursorMode = CursorMode.Auto;
	private Vector2 hotSpot = Vector2.zero;

	[SerializeField] Texture2D walkCursor;			// Cursor when over walkable layer
	[SerializeField] Texture2D attackCursor;		// Cursor when over attack layer
	[SerializeField] Texture2D unknownCursor;		// Cursor when over unknown or end stop layer
	[SerializeField] Texture2D objectHitCursor;		// Cursor when over object ya know

	[SerializeField] const int walkableLayerNumber = 8;
	[SerializeField] const int enemyLayerNumber = 9;
	[SerializeField] const int unknownLayerNumber = 10;
	[SerializeField] const int objectHitLayerNumber = 11;

	// Use this for initialization
	void Start () {
		this.cameraRaycaster = this.GetComponent<CameraRaycaster>();
		this.cameraRaycaster.layerChangeObservers += OnDelegateCalled;
	}
	
	// Update is called once per frame
	void Update () {
	}

	// Selects cursor icon based on what layer the cursor is hovering over
	void OnDelegateCalled(int currentLayer) {
		switch(currentLayer) {
		case walkableLayerNumber:
			Cursor.SetCursor(walkCursor, hotSpot, cursorMode);
			break;
		case enemyLayerNumber: 
			Cursor.SetCursor(attackCursor, hotSpot, cursorMode);
			break;
		case unknownLayerNumber:
			Cursor.SetCursor(unknownCursor, hotSpot, cursorMode);
			break;
		case objectHitLayerNumber: break;
			
			default:
			Cursor.SetCursor(walkCursor, hotSpot, cursorMode);
			return;
		}
	}
		
}
