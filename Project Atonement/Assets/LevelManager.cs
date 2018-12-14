using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private bool autoPlay = false;
	private float counter = 0;
	[SerializeField] float nextSceneTimer = 0.0f;
	[SerializeField] string timerSceneName = "";


	// Use this for initialization
	void Start () {
		if (nextSceneTimer != 0.0f) {
			autoPlay = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (autoPlay) {
			counter += Time.deltaTime;
			if (counter >= nextSceneTimer) {
				LaunchNextScene(timerSceneName);
			}
		}
	}

	public void LaunchNextScene(string nextScene) {
		SceneManager.LoadScene(nextScene);
	}
}
