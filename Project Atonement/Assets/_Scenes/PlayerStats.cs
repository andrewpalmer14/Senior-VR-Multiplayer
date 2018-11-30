using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats {

	public string name = "";
	public float maxHealth = 100.0f;
	public float playerHealth = 100.0f;
	public int prideXp = 0;
	public int wrathXp = 0;
	public int slothXp = 0;
	public int loveXp = 0;
	public int greedXp = 0;
	public int gluttonyXp = 0;
	public float xPos = 6.81f;
	public float yPos = 0.0f;
	public float zPos = -6.6f;

	//TODO: change the quest tracking to use a quest catelog object
	// Quest[] quests;
	// quest(id).questStarted   quest(id).questObjectiveComplete   quest(id).questCompleted

	public bool quest1Started = false;
	public bool quest1ObjectiveComplete = false;
	public bool quest1Completed = false;
	public bool prideRoute1Chosen = false;
	public bool wrathRoute1Chosen = false;
	public bool slothRoute1Chosen = false;
	/*public bool loveResponse1Chosen = false;
	public bool greedResponse1Chosen = false;
	public bool gluttonyResponse1Chosen = false;*/

	public bool quest2Started = false;
	public bool quest2ObjectiveComplete = false;
	public bool quest2Completed = false;
	public bool prideRoute2Chosen = false;
	public bool wrathRoute2Chosen = false;
	public bool slothRoute2Chosen = false;
	/*public bool loveResponse2Chosen = false;
	public bool greedResponse2Chosen = false;
	public bool gluttonyResponse2Chosen = false;*/

	public bool quest3Started = false;
	public bool quest3ObjectiveComplete = false;
	public bool quest3Completed = false;
	public bool prideRoute3Chosen = false;
	public bool wrathRoute3Chosen = false;
	public bool slothRoute3Chosen = false;
	/*public bool loveResponse3Chosen = false;
	public bool greedResponse3Chosen = false;
	public bool gluttonyResponse3Chosen = false;*/

	public PlayerStats() {
		
	}

	public bool QuestStarted(int questId) {
		if (questId == 1) {
			return quest1Started;
		} else if (questId == 2) {
			return quest2Started;
		} else if (questId == 3) {
			return quest3Started;
		} else {
			return false;
		}
	}

	public void SetQuestStarted(int questId) {
		if (questId == 1) {
			quest1Started = true;
		} else if (questId == 2) {
			quest2Started = true;
		} else if (questId == 3) {
			quest3Started = true;
		}
	}

	public void PrideRoute(int questId) {
		if (questId == 1) {
			prideRoute1Chosen = true;
		} else if (questId == 2) {
			prideRoute2Chosen = true;
		} else if (questId == 3) {
			prideRoute3Chosen = true;
		}
	}

	public bool GetPrideRoute(int questId) {
		if (questId == 1) {
			return prideRoute1Chosen;
		} else if (questId == 2) {
			return prideRoute2Chosen;
		} else if (questId == 3) {
			return prideRoute3Chosen;
		} else {
			return false;
		}
	}

	public void WrathRoute(int questId) {
		if (questId == 1) {
			wrathRoute1Chosen = true;
		} else if (questId == 2) {
			wrathRoute2Chosen = true;
		} else if (questId == 3) {
			wrathRoute3Chosen = true;
		}
	}

	public bool GetWrathRoute(int questId) {
		if (questId == 1) {
			return wrathRoute1Chosen;
		} else if (questId == 2) {
			return wrathRoute2Chosen;
		} else if (questId == 3) {
			return wrathRoute3Chosen;
		} else {
			return false;
		}
	}

	public void SlothRoute(int questId) {
		if (questId == 1) {
			slothRoute1Chosen = true;
		} else if (questId == 2) {
			slothRoute2Chosen = true;
		} else if (questId == 3) {
			slothRoute3Chosen = true;
		}
	}

	public bool GetSlothRoute(int questId) {
		if (questId == 1) {
			return slothRoute1Chosen;
		} else if (questId == 2) {
			return slothRoute2Chosen;
		} else if (questId == 3) {
			return slothRoute3Chosen;
		} else {
			return false;
		}
	}

	/*public void LoveResponse(int questId) {
		if (questId == 1) {
			loveResponse1Chosen = true;
		} else if (questId == 2) {
			loveResponse2Chosen = true;
		} else if (questId == 3) {
			loveResponse3Chosen = true;
		}
	}

	public bool GetLoveResponse(int questId) {
		if (questId == 1) {
			return loveResponse1Chosen;
		} else if (questId == 2) {
			return loveResponse2Chosen;
		} else if (questId == 3) {
			return loveResponse3Chosen;
		} else {
			return false;
		}
	}

	public void GreedResponse(int questId) {
		if (questId == 1) {
			greedResponse1Chosen = true;
		} else if (questId == 2) {
			greedResponse2Chosen = true;
		} else if (questId == 3) {
			greedResponse3Chosen = true;
		}
	}

	public bool GetGreedResponse(int questId) {
		if (questId == 1) {
			return greedResponse1Chosen;
		} else if (questId == 2) {
			return greedResponse2Chosen;
		} else if (questId == 3) {
			return greedResponse3Chosen;
		} else {
			return false;
		}
	}

	public void GluttonyResponse(int questId) {
		if (questId == 1) {
			gluttonyResponse1Chosen = true;
		} else if (questId == 2) {
			gluttonyResponse2Chosen = true;
		} else if (questId == 3) {
			gluttonyResponse3Chosen = true;
		}
	}

	public bool GetGluttonyResponse(int questId) {
		if (questId == 1) {
			return gluttonyResponse1Chosen;
		} else if (questId == 2) {
			return gluttonyResponse2Chosen;
		} else if (questId == 3) {
			return gluttonyResponse3Chosen;
		} else {
			return false;
		}
	}*/

	public bool QuestObjectiveComplete(int questId) {
		if (questId == 1) {
			return quest1ObjectiveComplete;
		} else if (questId == 2) {
			return quest2ObjectiveComplete;
		} else if (questId == 3) {
			return quest3ObjectiveComplete;
		} else {
			return false;
		}
	}

	public void SetQuestObjectiveComplete(int questId) {
		if (questId == 0) {
		} else if (questId == 1) {
			quest1ObjectiveComplete = true;
		} else if (questId == 2) {
			quest2ObjectiveComplete = true;
		} else if (questId == 3) {
			quest3ObjectiveComplete = true;
		}
	}

	public bool QuestCompleted(int questId) {
		if (questId == 1) {
			return quest1Completed;
		} else if (questId == 2) {
			return quest2Completed;
		} else if (questId == 3) {
			return quest3Completed;
		} else {
			return false;
		}
	}

	public void SetQuestCompleted(int questId) {
		if (questId == 0) {
		} else if (questId == 1) {
			quest1Completed = true;
		} else if (questId == 2) {
			quest2Completed = true;
		} else if (questId == 3) {
			quest3Completed = true;
		}
	}

}
