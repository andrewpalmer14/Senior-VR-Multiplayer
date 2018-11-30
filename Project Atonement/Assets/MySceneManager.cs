using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneManager : MonoBehaviour {

	private string prevScene;

	void Start() {
		//DontDestroyOnLoad(this);
	}

	public void GoToAndPlay(string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void Quit() {
		Application.Quit();
	}

	public void NewSoloGame() {
		Game.currentGame = new Game();
		Game.currentGame.playerStats.name = "Solo";
		SaveLoad.Save();
		prevScene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Level 1 - BLOOD");
	}

	public void ContinueSoloGame() {
		Game.currentGame = SaveLoad.savedGames[0];
		prevScene = SceneManager.GetActiveScene().name;
		SceneManager.LoadScene("Level 1 - BLOOD");
	}

	public string GetPreviousScene() {
		return prevScene;
	}

}
