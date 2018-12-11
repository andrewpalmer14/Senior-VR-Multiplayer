using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HideUI : MonoBehaviour {

    private bool isHidden = false;
    public GameObject uiCanvasObject;
    private float delay = 0.2f;
    private float time = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (CrossPlatformInputManager.GetButton("any"))
        {
            if (time > delay)
            {
                time = 0;
                this.isHidden = !isHidden;
                this.uiCanvasObject.SetActive(isHidden);
            }
        }
	}
}
