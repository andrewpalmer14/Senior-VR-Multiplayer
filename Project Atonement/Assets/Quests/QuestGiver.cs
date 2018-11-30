using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour {

	//TODO: create a branching quest layout where the response changes the task of the quest.
	[SerializeField] string questStartText = "press a to talk to villager";
	[SerializeField] string questCallToAction = "Please help!";
	[SerializeField] string pride = "Pride Response";
	[SerializeField] string wrath = "Wrath Response";
	[SerializeField] string sloth = "Sloth Response";
	[SerializeField] string questBeganText = "come back when you are done with your task";
	[SerializeField] string questObjectiveText = "current objective tracker";
	[SerializeField] string questPrideObjectiveText = "current pride objective tracker";
	[SerializeField] string questWrathObjectiveText = "current wrath objective tracker";
	[SerializeField] string questSlothObjectiveText = "current sloth objective tracker";
	[SerializeField] string questReadyToCompleteText = "press a to talk to villager";
	[SerializeField] string questGiverResponse = "How did the adventure go?";
	[SerializeField] string love = "Love Response";
	[SerializeField] string greed = "Greed Response";
	[SerializeField] string gluttony = "Gluttony Response";
	[SerializeField] string questCompletedText = "Completed: Adventure description here";
	[SerializeField] string questPrideCompletedText = "Completed: pride adv descr here";
	[SerializeField] string questWrathCompletedText = "Completed: wrath adv descr here";
	[SerializeField] string questSlothCompletedText = "Completed: sloth adv descr here";

	[SerializeField] bool killEnemiesQuest = false;
	
	public Enemy[] enemies = null;

	[SerializeField] bool findItemsQuest = false;
	[SerializeField] QuestItem[] items = null;

	[SerializeField] bool gameObjectControl = false;

	[SerializeField] GameObject[] gameObjectsToControl = null;

	private float time = 0.0f;
	private bool allEnemiesDestroyed = false;
	public int questId = 0;

	private bool questStarted = false;
	private bool prideRouteChosen = false;
	private bool wrathRouteChosen = false;
	private bool slothRouteChosen = false;

	private bool questObjectiveComplete = false;

	private bool questCompleted = false;
	/*private bool loveResponseChosen = false;
	private bool greedResponseChosen = false;
	private bool gluttonyResponseChosen = false;*/


	// Use this for initialization
	void Start () {
		UpdateQuestProgressFromSave();
		if (wrathRouteChosen && !questObjectiveComplete) {
			GetComponent<ThirdPersonEnemy>().enabled = true;
			GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
			GetComponent<Enemy>().enabled = true;
		}
	}

	private void UpdateQuestProgressFromSave() {
		questStarted = Game.currentGame.playerStats.QuestStarted(questId);
		questObjectiveComplete = Game.currentGame.playerStats.QuestObjectiveComplete(questId);
		questCompleted = Game.currentGame.playerStats.QuestCompleted(questId);
		prideRouteChosen = Game.currentGame.playerStats.GetPrideRoute(questId);
		wrathRouteChosen = Game.currentGame.playerStats.GetWrathRoute(questId);
		slothRouteChosen = Game.currentGame.playerStats.GetSlothRoute(questId);
		/*loveResponseChosen = Game.currentGame.playerStats.GetLoveResponse(questId);
		greedResponseChosen = Game.currentGame.playerStats.GetGreedResponse(questId);
		gluttonyResponseChosen = Game.currentGame.playerStats.GetGluttonyResponse(questId);*/
	}
	
	// Update is called once per frame
	void Update () {
		if (!questObjectiveComplete) {
			CheckQuest(); 
		} else {
			if (!allEnemiesDestroyed) {
				DestroyQuestEnemies();
			}
		}
		if (GetComponent<Enemy>().enabled) {
			if (GetComponent<Enemy>().GetEnemyHealth() <= 0) {
				questObjectiveComplete = true;
				questCompleted = true;
				Game.currentGame.playerStats.QuestObjectiveComplete(questId);
				Game.currentGame.playerStats.QuestCompleted(questId);
				SaveLoad.Save();
			}
		}
	}

	private void DestroyQuestEnemies() {
		for (int i = 0; i < enemies.Length; i++) {
			if (enemies[i] != null) {
				enemies[i].DestroyEnemy();
			}
			enemies[i] = null;
		}
		allEnemiesDestroyed = true;
	}

	public string SendQuestStartText() {
		return questStartText;
	}

	public string SendQuestBeganText() {
		return questBeganText;
	}

	public string SendQuestReadyToCompleteText() {
		return questReadyToCompleteText;
	}

	public string SendQuestCompletedText() {
		if (prideRouteChosen) {
			return questPrideCompletedText;
		} else if (wrathRouteChosen) {
			return questWrathCompletedText;
		} else if (slothRouteChosen) {
			return questSlothCompletedText;
		} else {
			return questCompletedText;
		}
	}

	private void CheckQuest() {
		if (killEnemiesQuest) {
			if (prideRouteChosen || slothRouteChosen) {
				time += Time.deltaTime;
				if (time >= 3.0f) {
					time = 0.0f;
					foreach (Enemy enemy in enemies) {
						if (enemy.ToString() != "null") {
							questObjectiveComplete = false;
							return;
						}
					}
					CompleteQuestObjective();
				}
			}
		} else {
			// find item quest
			if (prideRouteChosen || slothRouteChosen) {
				foreach (QuestItem item in items) {
					if (item.ItemFound() == false) {
						return;
					}
				}
				CompleteQuestObjective();	
			}
		}
	}

	public bool QuestIsStarted() {
		return questStarted;
	}

	public void StartQuest() {
		this.questStarted = true;
		Game.currentGame.playerStats.SetQuestStarted(questId);
		SaveLoad.Save();
	}

	public void CompleteQuestObjective() {
		questObjectiveComplete = true;
		Game.currentGame.playerStats.SetQuestObjectiveComplete(questId);
		SaveLoad.Save();
		print("Quest Objective Completed!");
	}

	public bool QuestIsReadyToBeCompleted() {
		return questObjectiveComplete;
	}

	public bool QuestIsCompleted() {
		return questCompleted;
	}

	public void CompleteQuest() {
		questCompleted = true;
		Game.currentGame.playerStats.SetQuestCompleted(questId);
		SaveLoad.Save();
	}

	public string QCTA() {
		return questCallToAction;
	}

	public string PrideR() {
		return  "B: " + pride;
	}

	public string WrathR() {
		return "X: " + wrath;
	}

	public string SlothR() {
		//slothRouteChosen = true;
		return "Y: " + sloth;
	}

	public string QGR() {
		return questGiverResponse;
	}

	public string LoveR() {
		return "B: " + love;
	}

	public string GreedR() {
		return "X: " + greed;
	}

	public string GluttonyR() {
		return "Y: " + gluttony;
	}

	public void PrideRouteTaken() {
		prideRouteChosen = true;
		Game.currentGame.playerStats.PrideRoute(questId);
	}

	public void WrathRouteTaken() {
		wrathRouteChosen = true;
		GetComponent<ThirdPersonEnemy>().enabled = true;
		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
		GetComponent<Enemy>().enabled = true;
		Game.currentGame.playerStats.WrathRoute(questId);
	}

	public void SlothRouteTaken() {
		slothRouteChosen = true;
		Game.currentGame.playerStats.SlothRoute(questId);
	}

	/*public void LoveResponseTaken() {
		loveResponseChosen = true;
		Game.currentGame.playerStats.LoveResponse(questId);
	}

	public void GreedResponseTaken() {
		greedResponseChosen = true;
		Game.currentGame.playerStats.GreedResponse(questId);
	}

	public void GluttonyResponseTaken() {
		gluttonyResponseChosen = true;
		Game.currentGame.playerStats.GluttonyResponse(questId);
	}*/

	public string GetQuestProgess() {
		if (!questStarted) {
			return "No current objectives";
		} else if (questStarted && !questObjectiveComplete) {
			if (prideRouteChosen) {
				return questPrideObjectiveText;
			} else if (wrathRouteChosen) {
				return questWrathObjectiveText;
			} else if (slothRouteChosen) {
				return questSlothObjectiveText;
			} else {
				return questObjectiveText;
			}
		} else if (!questCompleted) {
			return "Return to villager";
		} else  {
			return "No current objectives";
		}
	}
}
