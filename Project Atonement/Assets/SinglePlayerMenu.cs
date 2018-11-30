using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SinglePlayerMenu : MonoBehaviour {

	public GameObject serverMenu;
    private bool isActive = true;

    public Button newGameButton;
    public Button continueGameButton;
    public Button backButton;
    public Button quitGameButton;


    public void Start() {
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

	public void StartSoloServer() {
        Game.currentGame = new Game();
		Game.currentGame.playerStats.name = "Solo";
		SaveLoad.Save();
		SceneManager.LoadScene("Level 1 - BLOOD");
        //NetworkManager.singleton.StartHost();
        newGameButton.gameObject.SetActive(false);
        continueGameButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        quitGameButton.gameObject.SetActive(true);
        serverMenu.SetActive(false);
    }

    public void ContinueSoloServer() {
        Game.currentGame = SaveLoad.savedGames[0];
		SceneManager.LoadScene("Level 1 - BLOOD");
        newGameButton.gameObject.SetActive(false);
        continueGameButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        quitGameButton.gameObject.SetActive(true);
        //NetworkManager.singleton.StartHost();
        serverMenu.SetActive(false);
    }

    public void Quit() {
        SaveLoad.Save();
        NetworkManager.singleton.StopHost();
        //NetworkManager.singleton.StopServer();
        newGameButton.gameObject.SetActive(true);
        continueGameButton.gameObject.SetActive(true);
        if (SaveLoad.savedGames.Count > 0) {
            continueGameButton.interactable = true;
        } else {
            continueGameButton.interactable = false;
        }
        backButton.gameObject.SetActive(true);
        quitGameButton.gameObject.SetActive(false);
        //NetworkManager.singleton.StopAllCoroutines();
        //NetworkManager.singleton.StopServer();
        //NetworkManager.singleton.StopClient();
        SceneManager.LoadScene("01 Main Menu");
    }

    public void Back() {
        NetworkManager.singleton.StopHost();
        Destroy(NetworkManager.singleton);
        SceneManager.LoadScene("01 Main Menu");
        Destroy(this);

    }

    private void Update()
    {
        //Debug.Log("is network active" + NetworkManager.singleton.isNetworkActive.ToString());
        //Debug.Log("is client connected" + NetworkManager.singleton.IsClientConnected());
       /*  if (NetworkManager.singleton.isNetworkActive && !NetworkManager.singleton.IsClientConnected()) {
            Debug.Log("quit");
            NetworkManager.singleton.StopClient();
            NetworkManager.singleton.StopHost();
                    Destroy(this.gameObject);
            this.Quit();
       } */
        if (SceneManager.GetActiveScene().name != "02 Single Player") {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                serverMenu.SetActive(isActive);
                isActive = !isActive;
            }
        }
    }
   
}
