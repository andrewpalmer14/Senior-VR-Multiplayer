using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public enum Menu {
		MainMenu,
		NewGame,
		Continue
	}

	public Menu currentMenu;

	void OnGUI () {

		GUILayout.BeginArea(new Rect(0,0,Screen.width, Screen.height));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.BeginVertical();
		GUILayout.FlexibleSpace();

		if(currentMenu == Menu.MainMenu) {

			GUILayout.Box("Last Adventure");
			GUILayout.Space(10);

			if(GUILayout.Button("New Game")) {
				Game.currentGame = new Game();
				currentMenu = Menu.NewGame;
			}

			if(GUILayout.Button("Continue")) {
				SaveLoad.Load();
				currentMenu = Menu.Continue;
			}

			if(GUILayout.Button("Quit")) {
				Application.Quit();
			}
		}

		else if (currentMenu == Menu.NewGame) {

			GUILayout.Box("Name Your Character");
			GUILayout.Space(10);

			GUILayout.Label("Character Name");
			Game.currentGame.playerStats.name = GUILayout.TextField(Game.currentGame.playerStats.name, 20);
			/*GUILayout.Label("Rogue");
			Game.currentGame.rogue.name = GUILayout.TextField(Game.currentGame.rogue.name, 20);
			GUILayout.Label("Wizard");
			Game.currentGame.mage.name = GUILayout.TextField(Game.currentGame.mage.name, 20);*/

			if(GUILayout.Button("Save")) {
				//Save the current Game as a new saved Game
				SaveLoad.Save();
				//Move on to game...
				//Application.LoadLevel(1);
				SceneManager.LoadScene("Level 1 - BLOOD");
			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}

		}

		else if (currentMenu == Menu.Continue) {
			
			GUILayout.Box("Select Save File");
			GUILayout.Space(10);

			foreach(Game g in SaveLoad.savedGames) {
				if(GUILayout.Button(g.playerStats.name)) {
					Game.currentGame = g;
					//Move on to game...
					//Application.LoadLevel(1);
					SceneManager.LoadScene("Level 1 - BLOOD");
				}

			}

			GUILayout.Space(10);
			if(GUILayout.Button("Cancel")) {
				currentMenu = Menu.MainMenu;
			}
			
		}

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

	}
}
