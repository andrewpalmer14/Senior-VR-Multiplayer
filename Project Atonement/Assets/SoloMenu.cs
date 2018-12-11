using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoloMenu : MonoBehaviour {

	public GameObject soloMenu;
    private bool isActive = true;

    public Button newGameButton;
    public Button continueGameButton;
    public Button backButton;
    public Button quitGameButton;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		newGameButton.gameObject.SetActive(true);
        continueGameButton.gameObject.SetActive(true);
        if (SaveLoad.savedGames.Count > 0) {
            continueGameButton.interactable = true;
        } else {
            continueGameButton.interactable = false;
        }
        backButton.gameObject.SetActive(true);
        quitGameButton.gameObject.SetActive(false);
	}

	public void StartSoloGame() {
        Game.currentGame = new Game();
		Game.currentGame.playerStats.name = "Solo";
		SaveLoad.Save();
		SceneManager.LoadScene("Level 1 - BLOOD Single Player");
        newGameButton.gameObject.SetActive(false);
        continueGameButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        quitGameButton.gameObject.SetActive(true);
        soloMenu.SetActive(true);
    }

    public void ContinueSoloGame() {
        Game.currentGame = SaveLoad.savedGames[0];
		SceneManager.LoadScene("Level 1 - BLOOD Single Player");
        newGameButton.gameObject.SetActive(false);
        continueGameButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        quitGameButton.gameObject.SetActive(true);
        soloMenu.SetActive(true);
    }

    public void QuitGame() {
        SaveLoad.Save();
        Debug.Log("quit");
        Destroy(GameObject.Find("Player1"));
        newGameButton.gameObject.SetActive(true);
        continueGameButton.gameObject.SetActive(true);
        if (SaveLoad.savedGames.Count > 0) {
            continueGameButton.interactable = true;
        } else {
            continueGameButton.interactable = false;
        }
        backButton.gameObject.SetActive(true);
        quitGameButton.gameObject.SetActive(false);
        SceneManager.LoadScene("01 Main Menu");
    }

    public void Back() {
        SceneManager.LoadScene("01 Main Menu");
    }
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name != "02 Single Player") {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                soloMenu.SetActive(isActive);
                isActive = !isActive;
            }
        }
	}

}
