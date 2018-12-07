using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TestingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("fire1 " + CrossPlatformInputManager.GetButton("Fire1") + ", fire2 " + CrossPlatformInputManager.GetButton("Fire2") + ", fire3 " + CrossPlatformInputManager.GetButton("Fire3") + ", fire4 " + CrossPlatformInputManager.GetButton("Fire4") + ", fire5 " + CrossPlatformInputManager.GetButton("Fire5"));
    }   // fire 1 is a     
        // fire 2 is b  
        // fire 3 is x  (b)
        // fire 4 is y 
}
