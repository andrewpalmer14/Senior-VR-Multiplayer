using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {

	public GameObject serverMenu;
    public Text serverIP;
    private bool isActive = true;

    public Button hostGameButton;
    public Button joinGameButton;
    public Button backButton;
    public Button quitGameButton;
    public GameObject textField;



    public void Start() {
        hostGameButton.gameObject.SetActive(true);
        joinGameButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        textField.SetActive(true);
        quitGameButton.gameObject.SetActive(false);
    }

	public void StartServer() {
        Game.currentGame = new Game();
		Game.currentGame.playerStats.name = "MultiplayerHost";
		SaveLoad.Save();
		//SceneManager.LoadScene("Level 1 - BLOOD Multiplayer");

        hostGameButton.gameObject.SetActive(false);
        joinGameButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        textField.SetActive(false);
        quitGameButton.gameObject.SetActive(true);
        serverMenu.SetActive(false);
        NetworkManager.singleton.StartHost();
    }

    public void Quit() {
        hostGameButton.gameObject.SetActive(true);
        joinGameButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        textField.SetActive(true);
        quitGameButton.gameObject.SetActive(false);
        SceneManager.LoadScene("01 Main Menu");
    }

    public void StartClient()
    {
        Game.currentGame = new Game();
		Game.currentGame.playerStats.name = "MultiplayerClient";
		SaveLoad.Save();

        hostGameButton.gameObject.SetActive(true);
        joinGameButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
        textField.SetActive(true);
        quitGameButton.gameObject.SetActive(false);
        getIP();
        serverMenu.SetActive(false);
        NetworkManager.singleton.StartClient();
        Debug.Log("client connected: " + NetworkManager.singleton.client.isConnected);
        if (!NetworkManager.singleton.client.isConnected) {
            //NetworkManager.singleton.client.Disconnect();
            //SceneManager.LoadScene("01 Main Menu");
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "03 Multiplayer") {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                serverMenu.SetActive(isActive);
                isActive = !isActive;
            }
        }
    }
    public void getIP(){
        if (serverIP.text.Length > 0 && serverIP.text!= null){
           NetworkManager.singleton.networkAddress = serverIP.text;
        }
    }
}
