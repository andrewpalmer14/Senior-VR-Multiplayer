using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using System.Collections.Generic;

public class CameraRaycaster : MonoBehaviour {
	[SerializeField] int[] layerPriorities;

	float maxRaycastDepth = 100.0f;
	int topPriorityLayerLastFrame = -1;

	public delegate void OnLayerChange(int newLayer);
	public event OnLayerChange layerChangeObservers;

	public delegate void OnClickPriorityLayer(RaycastHit raycastHit, int layerHit);
	public event OnClickPriorityLayer mouseClickObservers;

    void Update() {
		if (EventSystem.current.IsPointerOverGameObject()) {
			layerChangeObservers(5);
			return;
		}

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] raycastHits = Physics.RaycastAll(ray, maxRaycastDepth);

		RaycastHit? priorityHit = FindTopPriorityHit(raycastHits);
		if (!priorityHit.HasValue) {
			NotifyObserversIfLayerChanged(0);
			return;
		}

		var layerHit = priorityHit.Value.collider.gameObject.layer;
		NotifyObserversIfLayerChanged(layerHit);

		if (Input.GetMouseButton(0)) {
			mouseClickObservers(priorityHit.Value, layerHit);
		}

    }

	void NotifyObserversIfLayerChanged(int newLayer) {
		if (newLayer != topPriorityLayerLastFrame) {
			topPriorityLayerLastFrame = newLayer;
			layerChangeObservers(newLayer);
		}
	}

	RaycastHit? FindTopPriorityHit(RaycastHit[] raycastHits) {
		List<int> layersOfHitColliders = new List<int>();
		foreach (RaycastHit hit in raycastHits) {
			layersOfHitColliders.Add(hit.collider.gameObject.layer);
		}

		foreach (int layer in layerPriorities) {
			foreach (RaycastHit hit in raycastHits) {
				if (hit.collider.gameObject.layer == layer) {
					return hit;
				}
			}
		}
		return null;

	}
}
