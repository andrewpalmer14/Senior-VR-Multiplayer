using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour {

	[SerializeField] Player playerPrefab;
	[SerializeField] GameObject playerParent;
	[SerializeField] GameObject multiplayerCamPrefab;

	private Player player = null;
	private Camera camera = null;

	private bool isActive = true;

	private GameObject soloMenu;

	void Start() {
		if (GameObject.Find("SoloMenu")) {
			StartSinglePlayer();
			isActive = !isActive;
			soloMenu = GameObject.Find("SoloMenu");
			soloMenu.SetActive(false);
			Debug.Log("starting single player");
		} else {
			StartMultiplayer();
			Debug.Log("start multiplayer");
		}
	}

	void StartSinglePlayer() {
		Instantiate(playerPrefab, new Vector3(SaveLoad.savedGames[0].playerStats.xPos,
											  SaveLoad.savedGames[0].playerStats.yPos,
											  SaveLoad.savedGames[0].playerStats.zPos ), Quaternion.identity, playerParent.transform); 
	}

	void StartMultiplayer() {
		if (NetworkManager.singleton.numPlayers == 0) {
			//NetworkManager.singleton.StartHost();
			//NetworkManager.Instantiate(playerPrefab, 
				//					   new Vector3(NetworkManager.singleton.startPositions[0].position.x, NetworkManager.singleton.startPositions[0].position.y, NetworkManager.singleton.startPositions[0].position.z), 
				//					   Quaternion.identity, playerParent.transform);
			Debug.Log("Starting Host");
		} else {
			//NetworkManager.singleton.StartClient();
			//NetworkManager.Instantiate(playerPrefab, 
					//				   new Vector3(NetworkManager.singleton.startPositions[1].position.x, NetworkManager.singleton.startPositions[1].position.y, NetworkManager.singleton.startPositions[1].position.z), 
					//				   Quaternion.identity, playerParent.transform);
			Debug.Log("Starting Client");
		}
	}

	void Update() {
		if (player == null) {
			FindPlayer();
		}

		if (camera == null) {
			FindCamera();
		}

		if (SceneManager.GetActiveScene().name != "02 Single Player") {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
				isActive = !isActive;
                soloMenu.SetActive(isActive);
            }
        }
	}

	void FindPlayer() {
		player = FindObjectOfType<Player>();
		if (player != null) {
			Debug.Log("Found Player!!!");
			player.SetPlayerMaxHealth(Game.currentGame.playerStats.maxHealth);
			player.SetPlayerHealth(Game.currentGame.playerStats.playerHealth);
			player.name = Game.currentGame.playerStats.name;
			player.IncreasePride(Game.currentGame.playerStats.prideXp);
			player.IncreaseWrath(Game.currentGame.playerStats.wrathXp);
			player.IncreaseSloth(Game.currentGame.playerStats.slothXp);
			player.IncreaseLove(Game.currentGame.playerStats.loveXp);
			player.IncreaseGreed(Game.currentGame.playerStats.greedXp);
			player.IncreaseGluttony(Game.currentGame.playerStats.gluttonyXp);
			Enemy[] enemies = FindObjectsOfType<Enemy>();
			foreach (Enemy enemy in enemies) {
				enemy.SetTarget(this.player.transform);
			}
		}
	}

	void FindCamera() {
		camera = FindObjectOfType<Camera>();
		if (camera == null) {
			Instantiate(multiplayerCamPrefab, Vector3.one, Quaternion.identity, playerParent.transform);
		}
	}

}
