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

	public bool quest2Started = false;
	public bool quest2ObjectiveComplete = false;
	public bool quest2Completed = false;
	public bool prideRoute2Chosen = false;
	public bool wrathRoute2Chosen = false;
	public bool slothRoute2Chosen = false;

	public bool quest3Started = false;
	public bool quest3ObjectiveComplete = false;
	public bool quest3Completed = false;
	public bool prideRoute3Chosen = false;
	public bool wrathRoute3Chosen = false;
	public bool slothRoute3Chosen = false;

    public bool quest4Started = false;
    public bool quest4ObjectiveComplete = false;
    public bool quest4Completed = false;
    public bool prideRoute4Chosen = false;
    public bool wrathRoute4Chosen = false;
    public bool slothRoute4Chosen = false;

    public bool quest5Started = false;
    public bool quest5ObjectiveComplete = false;
    public bool quest5Completed = false;
    public bool prideRoute5Chosen = false;
    public bool wrathRoute5Chosen = false;
    public bool slothRoute5Chosen = false;

    public bool quest6Started = false;
    public bool quest6ObjectiveComplete = false;
    public bool quest6Completed = false;
    public bool prideRoute6Chosen = false;
    public bool wrathRoute6Chosen = false;
    public bool slothRoute6Chosen = false;

    public bool quest7Started = false;
    public bool quest7ObjectiveComplete = false;
    public bool quest7Completed = false;
    public bool prideRoute7Chosen = false;
    public bool wrathRoute7Chosen = false;
    public bool slothRoute7Chosen = false;

    public bool quest8Started = false;
    public bool quest8ObjectiveComplete = false;
    public bool quest8Completed = false;
    public bool prideRoute8Chosen = false;
    public bool wrathRoute8Chosen = false;
    public bool slothRoute8Chosen = false;

    public bool quest9Started = false;
    public bool quest9ObjectiveComplete = false;
    public bool quest9Completed = false;
    public bool prideRoute9Chosen = false;
    public bool wrathRoute9Chosen = false;
    public bool slothRoute9Chosen = false;

    public bool quest10Started = false;
    public bool quest10ObjectiveComplete = false;
    public bool quest10Completed = false;
    public bool prideRoute10Chosen = false;
    public bool wrathRoute10Chosen = false;
    public bool slothRoute10Chosen = false;

    public bool quest11Started = false;
    public bool quest11ObjectiveComplete = false;
    public bool quest11Completed = false;
    public bool prideRoute11Chosen = false;
    public bool wrathRoute11Chosen = false;
    public bool slothRoute11Chosen = false;

    public bool quest12Started = false;
    public bool quest12ObjectiveComplete = false;
    public bool quest12Completed = false;
    public bool prideRoute12Chosen = false;
    public bool wrathRoute12Chosen = false;
    public bool slothRoute12Chosen = false;

    public bool quest13Started = false;
    public bool quest13ObjectiveComplete = false;
    public bool quest13Completed = false;
    public bool prideRoute13Chosen = false;
    public bool wrathRoute13Chosen = false;
    public bool slothRoute13Chosen = false;

    public bool quest14Started = false;
    public bool quest14ObjectiveComplete = false;
    public bool quest14Completed = false;
    public bool prideRoute14Chosen = false;
    public bool wrathRoute14Chosen = false;
    public bool slothRoute14Chosen = false;

    public bool quest15Started = false;
    public bool quest15ObjectiveComplete = false;
    public bool quest15Completed = false;
    public bool prideRoute15Chosen = false;
    public bool wrathRoute15Chosen = false;
    public bool slothRoute15Chosen = false;

    public bool quest16Started = false;
    public bool quest16ObjectiveComplete = false;
    public bool quest16Completed = false;
    public bool prideRoute16Chosen = false;
    public bool wrathRoute16Chosen = false;
    public bool slothRoute16Chosen = false;

    public bool quest17Started = false;
    public bool quest17ObjectiveComplete = false;
    public bool quest17Completed = false;
    public bool prideRoute17Chosen = false;
    public bool wrathRoute17Chosen = false;
    public bool slothRoute17Chosen = false;

    public bool quest18Started = false;
    public bool quest18ObjectiveComplete = false;
    public bool quest18Completed = false;
    public bool prideRoute18Chosen = false;
    public bool wrathRoute18Chosen = false;
    public bool slothRoute18Chosen = false;

    public bool quest19Started = false;
    public bool quest19ObjectiveComplete = false;
    public bool quest19Completed = false;
    public bool prideRoute19Chosen = false;
    public bool wrathRoute19Chosen = false;
    public bool slothRoute19Chosen = false;

    public bool quest20Started = false;
    public bool quest20ObjectiveComplete = false;
    public bool quest20Completed = false;
    public bool prideRoute20Chosen = false;
    public bool wrathRoute20Chosen = false;
    public bool slothRoute20Chosen = false;

    public bool quest21Started = false;
    public bool quest21ObjectiveComplete = false;
    public bool quest21Completed = false;
    public bool prideRoute21Chosen = false;
    public bool wrathRoute21Chosen = false;
    public bool slothRoute21Chosen = false;

    public bool quest22Started = false;
    public bool quest22ObjectiveComplete = false;
    public bool quest22Completed = false;
    public bool prideRoute22Chosen = false;
    public bool wrathRoute22Chosen = false;
    public bool slothRoute22Chosen = false;

    public bool quest23Started = false;
    public bool quest23ObjectiveComplete = false;
    public bool quest23Completed = false;
    public bool prideRoute23Chosen = false;
    public bool wrathRoute23Chosen = false;
    public bool slothRoute23Chosen = false;

    public bool quest24Started = false;
    public bool quest24ObjectiveComplete = false;
    public bool quest24Completed = false;
    public bool prideRoute24Chosen = false;
    public bool wrathRoute24Chosen = false;
    public bool slothRoute24Chosen = false;

    public bool quest25Started = false;
    public bool quest25ObjectiveComplete = false;
    public bool quest25Completed = false;
    public bool prideRoute25Chosen = false;
    public bool wrathRoute25Chosen = false;
    public bool slothRoute25Chosen = false;

    public bool quest26Started = false;
    public bool quest26ObjectiveComplete = false;
    public bool quest26Completed = false;
    public bool prideRoute26Chosen = false;
    public bool wrathRoute26Chosen = false;
    public bool slothRoute26Chosen = false;

    public bool quest27Started = false;
    public bool quest27ObjectiveComplete = false;
    public bool quest27Completed = false;
    public bool prideRoute27Chosen = false;
    public bool wrathRoute27Chosen = false;
    public bool slothRoute27Chosen = false;

    public bool quest28Started = false;
    public bool quest28ObjectiveComplete = false;
    public bool quest28Completed = false;
    public bool prideRoute28Chosen = false;
    public bool wrathRoute28Chosen = false;
    public bool slothRoute28Chosen = false;

    public PlayerStats() {
		
	}

	public bool QuestStarted(int questId) {
		if (questId == 1) {
			return quest1Started;
		} else if (questId == 2) {
			return quest2Started;
		} else if (questId == 3) {
			return quest3Started;
		} else if (questId == 4) {
			return quest5Started;
		} else if (questId == 5) {
            return quest6Started;
        }
        else if (questId == 6)
        {
            return quest6Started;
        }
        else if (questId == 7)
        {
            return quest7Started;
        }
        else if (questId == 8)
        {
            return quest8Started;
        }
        else if (questId == 9)
        {
            return quest9Started;
        }
        else if (questId == 10)
        {
            return quest10Started;
        }
        else if (questId == 11)
        {
            return quest11Started;
        }
        else if (questId == 12)
        {
            return quest12Started;
        }
        else if (questId == 13)
        {
            return quest13Started;
        }
        else if (questId == 14)
        {
            return quest14Started;
        }
        else if (questId == 15)
        {
            return quest15Started;
        }
        else if (questId == 16)
        {
            return quest16Started;
        }
        else if (questId == 17)
        {
            return quest17Started;
        }
        else if (questId == 18)
        {
            return quest18Started;
        }
        else if (questId == 19)
        {
            return quest19Started;
        }
        else if (questId == 20)
        {
            return quest20Started;
        }
        else if (questId == 21)
        {
            return quest21Started;
        }
        else if (questId == 22)
        {
            return quest22Started;
        }
        else if (questId == 23)
        {
            return quest23Started;
        }
        else if (questId == 24)
        {
            return quest24Started;
        }
        else if (questId == 25)
        {
            return quest25Started;
        } else if (questId == 26)
        {
            return quest26Started;
        } else if (questId == 27)
        {
            return quest27Started;
        } else if (questId == 28)
        {
            return quest28Started;
        }
        else
        {
			return false;
		}
	}

	public void SetQuestStarted(int questId) {
        if (questId == 1)
        {
            quest1Started = true;
        }
        else if (questId == 2)
        {
             quest2Started = true;
        }
        else if (questId == 3)
        {
            quest3Started = true;
        }
        else if (questId == 4)
        {
            quest5Started = true;
        }
        else if (questId == 5)
        {
            quest6Started = true;
        }
        else if (questId == 6)
        {
             quest6Started = true;
        }
        else if (questId == 7)
        {
             quest7Started = true;
        }
        else if (questId == 8)
        {
             quest8Started = true;
        }
        else if (questId == 9)
        {
             quest9Started = true;
        }
        else if (questId == 10)
        {
             quest10Started = true;
        }
        else if (questId == 11)
        {
             quest11Started = true;
        }
        else if (questId == 12)
        {
             quest12Started = true;
        }
        else if (questId == 13)
        {
             quest13Started = true;
        }
        else if (questId == 14)
        {
             quest14Started = true;
        }
        else if (questId == 15)
        {
             quest15Started = true;
        }
        else if (questId == 16)
        {
             quest16Started = true;
        }
        else if (questId == 17)
        {
             quest17Started = true;
        }
        else if (questId == 18)
        {
             quest18Started = true;
        }
        else if (questId == 19)
        {
             quest19Started = true;
        }
        else if (questId == 20)
        {
             quest20Started = true;
        }
        else if (questId == 21)
        {
             quest21Started = true;
        }
        else if (questId == 22)
        {
             quest22Started = true;
        }
        else if (questId == 23)
        {
             quest23Started = true;
        }
        else if (questId == 24)
        {
             quest24Started = true;
        }
        else if (questId == 25)
        {
             quest25Started = true;
        }
        else if (questId == 26)
        {
             quest26Started = true;
        }
        else if (questId == 27)
        {
             quest27Started = true;
        }
        else if (questId == 28)
        {
             quest28Started = true;
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
        }
        else if (questId == 4)
        {
            return prideRoute4Chosen;
        }
        else if (questId == 5)
        {
            return prideRoute5Chosen;
        }
        else if (questId == 6)
        {
            return prideRoute6Chosen;
        }
        else if (questId == 7)
        {
            return prideRoute7Chosen;
        }
        else if (questId == 8)
        {
            return prideRoute8Chosen;
        }
        else if (questId == 9)
        {
            return prideRoute9Chosen;
        }
        else if (questId == 10)
        {
            return prideRoute10Chosen;
        }
        else if (questId == 11)
        {
            return prideRoute11Chosen;
        }
        else if (questId == 12)
        {
            return prideRoute12Chosen;
        }
        else if (questId == 13)
        {
            return prideRoute13Chosen;
        }
        else if (questId == 14)
        {
            return prideRoute14Chosen;
        }
        else if (questId == 15)
        {
            return prideRoute15Chosen;
        }
        else if (questId == 16)
        {
            return prideRoute16Chosen;
        }
        else if (questId == 17)
        {
            return prideRoute17Chosen;
        }
        else if (questId == 18)
        {
            return prideRoute18Chosen;
        }
        else if (questId == 19)
        {
            return prideRoute19Chosen;
        }
        else if (questId == 20)
        {
            return prideRoute20Chosen;
        }
        else if (questId == 21)
        {
            return prideRoute21Chosen;
        }
        else if (questId == 22)
        {
            return prideRoute22Chosen;
        }
        else if (questId == 23)
        {
            return prideRoute23Chosen;
        }
        else if (questId == 24)
        {
            return prideRoute24Chosen;
        }
        else if (questId == 25)
        {
            return prideRoute25Chosen;
        }
        else if (questId == 26)
        {
            return prideRoute26Chosen;
        }
        else if (questId == 27)
        {
            return prideRoute27Chosen;
        }
        else if (questId == 28)
        {
            return prideRoute28Chosen;
        }
        else {
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
        else if (questId == 4)
        {
            wrathRoute4Chosen = true;
        }
        else if (questId == 5)
        {
            wrathRoute5Chosen = true;
        }
        else if (questId == 6)
        {
            wrathRoute6Chosen = true;
        }
        else if (questId == 7)
        {
            wrathRoute7Chosen = true;
        }
        else if (questId == 8)
        {
            wrathRoute8Chosen = true;
        }
        else if (questId == 9)
        {
            wrathRoute9Chosen = true;
        }
        else if (questId == 10)
        {
            wrathRoute10Chosen = true;
        }
        else if (questId == 11)
        {
            wrathRoute11Chosen = true;
        }
        else if (questId == 12)
        {
            wrathRoute12Chosen = true;
        }
        else if (questId == 13)
        {
            wrathRoute13Chosen = true;
        }
        else if (questId == 14)
        {
            wrathRoute14Chosen = true;
        }
        else if (questId == 15)
        {
            wrathRoute15Chosen = true;
        }
        else if (questId == 16)
        {
            wrathRoute16Chosen = true;
        }
        else if (questId == 17)
        {
            wrathRoute17Chosen = true;
        }
        else if (questId == 18)
        {
            wrathRoute18Chosen = true;
        }
        else if (questId == 19)
        {
            wrathRoute19Chosen = true;
        }
        else if (questId == 20)
        {
            wrathRoute20Chosen = true;
        }
        else if (questId == 21)
        {
            wrathRoute21Chosen = true;
        }
        else if (questId == 22)
        {
            wrathRoute22Chosen = true;
        }
        else if (questId == 23)
        {
            wrathRoute23Chosen = true;
        }
        else if (questId == 24)
        {
            wrathRoute24Chosen = true;
        }
        else if (questId == 25)
        {
            wrathRoute25Chosen = true;
        }
        else if (questId == 26)
        {
            wrathRoute26Chosen = true;
        }
        else if (questId == 27)
        {
            wrathRoute27Chosen = true;
        }
        else if (questId == 28)
        {
            wrathRoute28Chosen = true;
        }
    }

	public bool GetWrathRoute(int questId) {
		if (questId == 1) {
			return wrathRoute1Chosen;
		} else if (questId == 2) {
			return wrathRoute2Chosen;
		} else if (questId == 3) {
			return wrathRoute3Chosen;
		}
        else if (questId == 4)
        {
            return wrathRoute4Chosen;
        }
        else if (questId == 5)
        {
            return wrathRoute5Chosen;
        }
        else if (questId == 6)
        {
            return wrathRoute6Chosen;
        }
        else if (questId == 7)
        {
            return wrathRoute7Chosen;
        }
        else if (questId == 8)
        {
            return wrathRoute8Chosen;
        }
        else if (questId == 9)
        {
            return wrathRoute9Chosen;
        }
        else if (questId == 10)
        {
            return wrathRoute10Chosen;
        }
        else if (questId == 11)
        {
            return wrathRoute11Chosen;
        }
        else if (questId == 12)
        {
            return wrathRoute12Chosen;
        }
        else if (questId == 13)
        {
            return wrathRoute13Chosen;
        }
        else if (questId == 14)
        {
            return wrathRoute14Chosen;
        }
        else if (questId == 15)
        {
            return wrathRoute15Chosen;
        }
        else if (questId == 16)
        {
            return wrathRoute16Chosen;
        }
        else if (questId == 17)
        {
            return wrathRoute17Chosen;
        }
        else if (questId == 18)
        {
            return wrathRoute18Chosen;
        }
        else if (questId == 19)
        {
            return wrathRoute19Chosen;
        }
        else if (questId == 20)
        {
            return wrathRoute20Chosen;
        }
        else if (questId == 21)
        {
            return wrathRoute21Chosen;
        }
        else if (questId == 22)
        {
            return wrathRoute22Chosen;
        }
        else if (questId == 23)
        {
            return wrathRoute23Chosen;
        }
        else if (questId == 24)
        {
            return wrathRoute24Chosen;
        }
        else if (questId == 25)
        {
            return wrathRoute25Chosen;
        }
        else if (questId == 26)
        {
            return wrathRoute26Chosen;
        }
        else if (questId == 27)
        {
            return wrathRoute27Chosen;
        }
        else if (questId == 28)
        {
            return wrathRoute28Chosen;
        }
        else {
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
        else if (questId == 4)
        {
            slothRoute4Chosen = true;
        }
        else if (questId == 5)
        {
            slothRoute5Chosen = true;
        }
        else if (questId == 6)
        {
            slothRoute6Chosen = true;
        }
        else if (questId == 7)
        {
            slothRoute7Chosen = true;
        }
        else if (questId == 8)
        {
            slothRoute8Chosen = true;
        }
        else if (questId == 9)
        {
            slothRoute9Chosen = true;
        }
        else if (questId == 10)
        {
            slothRoute10Chosen = true;
        }
        else if (questId == 11)
        {
            slothRoute11Chosen = true;
        }
        else if (questId == 12)
        {
            slothRoute12Chosen = true;
        }
        else if (questId == 13)
        {
            slothRoute13Chosen = true;
        }
        else if (questId == 14)
        {
            slothRoute14Chosen = true;
        }
        else if (questId == 15)
        {
            slothRoute15Chosen = true;
        }
        else if (questId == 16)
        {
            slothRoute16Chosen = true;
        }
        else if (questId == 17)
        {
            slothRoute17Chosen = true;
        }
        else if (questId == 18)
        {
            slothRoute18Chosen = true;
        }
        else if (questId == 19)
        {
            slothRoute19Chosen = true;
        }
        else if (questId == 20)
        {
            slothRoute20Chosen = true;
        }
        else if (questId == 21)
        {
            slothRoute21Chosen = true;
        }
        else if (questId == 22)
        {
            slothRoute22Chosen = true;
        }
        else if (questId == 23)
        {
            slothRoute23Chosen = true;
        }
        else if (questId == 24)
        {
            slothRoute24Chosen = true;
        }
        else if (questId == 25)
        {
            slothRoute25Chosen = true;
        }
        else if (questId == 26)
        {
            slothRoute26Chosen = true;
        }
        else if (questId == 27)
        {
            slothRoute27Chosen = true;
        }
        else if (questId == 28)
        {
            slothRoute28Chosen = true;
        }
        
    }

	public bool GetSlothRoute(int questId) {
		if (questId == 1) {
			return slothRoute1Chosen;
		} else if (questId == 2) {
			return slothRoute2Chosen;
		} else if (questId == 3) {
			return slothRoute3Chosen;
		}
        else if (questId == 4)
        {
            return slothRoute4Chosen;
        }
        else if (questId == 5)
        {
            return slothRoute5Chosen;
        }
        else if (questId == 6)
        {
            return slothRoute6Chosen;
        }
        else if (questId == 7)
        {
            return slothRoute7Chosen;
        }
        else if (questId == 8)
        {
            return slothRoute8Chosen;
        }
        else if (questId == 9)
        {
            return slothRoute9Chosen;
        }
        else if (questId == 10)
        {
            return slothRoute10Chosen;
        }
        else if (questId == 11)
        {
            return slothRoute11Chosen;
        }
        else if (questId == 12)
        {
            return slothRoute12Chosen;
        }
        else if (questId == 13)
        {
            return slothRoute13Chosen;
        }
        else if (questId == 14)
        {
            return slothRoute14Chosen;
        }
        else if (questId == 15)
        {
            return slothRoute15Chosen;
        }
        else if (questId == 16)
        {
            return slothRoute16Chosen;
        }
        else if (questId == 17)
        {
            return slothRoute17Chosen;
        }
        else if (questId == 18)
        {
            return slothRoute18Chosen;
        }
        else if (questId == 19)
        {
            return slothRoute19Chosen;
        }
        else if (questId == 20)
        {
            return slothRoute20Chosen;
        }
        else if (questId == 21)
        {
            return slothRoute21Chosen;
        }
        else if (questId == 22)
        {
            return slothRoute22Chosen;
        }
        else if (questId == 23)
        {
            return slothRoute23Chosen;
        }
        else if (questId == 24)
        {
            return slothRoute24Chosen;
        }
        else if (questId == 25)
        {
            return slothRoute25Chosen;
        }
        else if (questId == 26)
        {
            return slothRoute26Chosen;
        }
        else if (questId == 27)
        {
            return slothRoute27Chosen;
        }
        else if (questId == 28)
        {
            return slothRoute28Chosen;
        }
        else {
			return false;
		}
	}

	public bool QuestObjectiveComplete(int questId) {
		if (questId == 1) {
			return quest1ObjectiveComplete;
		} else if (questId == 2) {
			return quest2ObjectiveComplete;
		} else if (questId == 3) {
			return quest3ObjectiveComplete;
		}
        else if (questId == 4)
        {
            return quest4ObjectiveComplete;
        }
        else if (questId == 5)
        {
            return quest5ObjectiveComplete;
        }
        else if (questId == 6)
        {
            return quest6ObjectiveComplete;
        }
        else if (questId == 7)
        {
            return quest7ObjectiveComplete;
        }
        else if (questId == 8)
        {
            return quest8ObjectiveComplete;
        }
        else if (questId == 9)
        {
            return quest9ObjectiveComplete;
        }
        else if (questId == 10)
        {
            return quest10ObjectiveComplete;
        }
        else if (questId == 11)
        {
            return quest11ObjectiveComplete;
        }
        else if (questId == 12)
        {
            return quest12ObjectiveComplete;
        }
        else if (questId == 13)
        {
            return quest13ObjectiveComplete;
        }
        else if (questId == 14)
        {
            return quest14ObjectiveComplete;
        }
        else if (questId == 15)
        {
            return quest15ObjectiveComplete;
        }
        else if (questId == 16)
        {
            return quest16ObjectiveComplete;
        }
        else if (questId == 17)
        {
            return quest17ObjectiveComplete;
        }
        else if (questId == 18)
        {
            return quest18ObjectiveComplete;
        }
        else if (questId == 19)
        {
            return quest19ObjectiveComplete;
        }
        else if (questId == 20)
        {
            return quest20ObjectiveComplete;
        }
        else if (questId == 21)
        {
            return quest21ObjectiveComplete;
        }
        else if (questId == 22)
        {
            return quest22ObjectiveComplete;
        }
        else if (questId == 23)
        {
            return quest23ObjectiveComplete;
        }
        else if (questId == 24)
        {
            return quest24ObjectiveComplete;
        }
        else if (questId == 25)
        {
            return quest25ObjectiveComplete;
        }
        else if (questId == 26)
        {
            return quest26ObjectiveComplete;
        }
        else if (questId == 27)
        {
            return quest27ObjectiveComplete;
        }
        else if (questId == 28)
        {
            return quest28ObjectiveComplete;
        }
        else {
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
        else if (questId == 4)
        {
            quest4ObjectiveComplete = true;
        }
        else if (questId == 5)
        {
            quest5ObjectiveComplete = true;
        }
        else if (questId == 6)
        {
            quest6ObjectiveComplete = true;
        }
        else if (questId == 7)
        {
            quest7ObjectiveComplete = true;
        }
        else if (questId == 8)
        {
            quest8ObjectiveComplete = true;
        }
        else if (questId == 9)
        {
            quest9ObjectiveComplete = true;
        }
        else if (questId == 10)
        {
            quest10ObjectiveComplete = true;
        }
        else if (questId == 11)
        {
            quest11ObjectiveComplete = true;
        }
        else if (questId == 12)
        {
            quest12ObjectiveComplete = true;
        }
        else if (questId == 13)
        {
            quest13ObjectiveComplete = true;
        }
        else if (questId == 14)
        {
            quest14ObjectiveComplete = true;
        }
        else if (questId == 15)
        {
            quest15ObjectiveComplete = true;
        }
        else if (questId == 16)
        {
            quest16ObjectiveComplete = true;
        }
        else if (questId == 17)
        {
            quest17ObjectiveComplete = true;
        }
        else if (questId == 18)
        {
            quest18ObjectiveComplete = true;
        }
        else if (questId == 19)
        {
            quest19ObjectiveComplete = true;
        }
        else if (questId == 20)
        {
            quest20ObjectiveComplete = true;
        }
        else if (questId == 21)
        {
            quest21ObjectiveComplete = true;
        }
        else if (questId == 22)
        {
            quest22ObjectiveComplete = true;
        }
        else if (questId == 23)
        {
            quest23ObjectiveComplete = true;
        }
        else if (questId == 24)
        {
            quest24ObjectiveComplete = true;
        }
        else if (questId == 25)
        {
            quest25ObjectiveComplete = true;
        }
        else if (questId == 26)
        {
            quest2ObjectiveComplete = true;
        }
        else if (questId == 26)
        {
            quest3ObjectiveComplete = true;
        }
        else if (questId == 27)
        {
            quest27ObjectiveComplete = true;
        }
        else if (questId == 28)
        {
            quest28ObjectiveComplete = true;
        }
        
    }

	public bool QuestCompleted(int questId) {
		if (questId == 1) {
			return quest1Completed;
		} else if (questId == 2) {
			return quest2Completed;
		} else if (questId == 3) {
			return quest3Completed;
		}
        else if (questId == 4)
        {
            return quest4Completed;
        }
        else if (questId == 5)
        {
            return quest5Completed;
        }
        else if (questId == 6)
        {
            return quest6Completed;
        }
        else if (questId == 7)
        {
            return quest7Completed;
        }
        else if (questId == 8)
        {
            return quest8Completed;
        }
        else if (questId == 9)
        {
            return quest9Completed;
        }
        else if (questId == 10)
        {
            return quest10Completed;
        }
        else if (questId == 11)
        {
            return quest11Completed;
        }
        else if (questId == 12)
        {
            return quest12Completed;
        }
        else if (questId == 13)
        {
            return quest13Completed;
        }
        else if (questId == 14)
        {
            return quest14Completed;
        }
        else if (questId == 15)
        {
            return quest15Completed;
        }
        else if (questId == 16)
        {
            return quest16Completed;
        }
        else if (questId == 17)
        {
            return quest17Completed;
        }
        else if (questId == 18)
        {
            return quest18Completed;
        }
        else if (questId == 19)
        {
            return quest19Completed;
        }
        else if (questId == 20)
        {
            return quest20Completed;
        }
        else if (questId == 21)
        {
            return quest21Completed;
        }
        else if (questId == 22)
        {
            return quest22Completed;
        }
        else if (questId == 23)
        {
            return quest23Completed;
        }
        else if (questId == 24)
        {
            return quest24Completed;
        }
        else if (questId == 25)
        {
            return quest25Completed;
        }
        else if (questId == 26)
        {
            return quest26Completed;
        }
        else if (questId == 27)
        {
            return quest27Completed;
        }
        else if (questId == 28)
        {
            return quest28Completed;
        }
        else {
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
        else if (questId == 4)
        {
            quest4Completed = true;
        }
        else if (questId == 5)
        {
            quest5Completed = true;
        }
        else if (questId == 6)
        {
            quest6Completed = true;
        }
        else if (questId == 7)
        {
            quest7Completed = true;
        }
        else if (questId == 8)
        {
            quest8Completed = true;
        }
        else if (questId == 9)
        {
            quest9Completed = true;
        }
        else if (questId == 10)
        {
            quest10Completed = true;
        }
        else if (questId == 11)
        {
            quest11Completed = true;
        }
        else if (questId == 12)
        {
            quest12Completed = true;
        }
        else if (questId == 13)
        {
            quest13Completed = true;
        }
        else if (questId == 14)
        {
            quest14Completed = true;
        }
        else if (questId == 15)
        {
            quest15Completed = true;
        }
        else if (questId == 16)
        {
            quest16Completed = true;
        }
        else if (questId == 17)
        {
            quest17Completed = true;
        }
        else if (questId == 18)
        {
            quest18Completed = true;
        }
        else if (questId == 19)
        {
            quest19Completed = true;
        }
        else if (questId == 20)
        {
            quest20Completed = true;
        }
        else if (questId == 21)
        {
            quest21Completed = true;
        }
        else if (questId == 22)
        {
            quest22Completed = true;
        }
        else if (questId == 23)
        {
            quest23Completed = true;
        }
        else if (questId == 24)
        {
            quest24Completed = true;
        }
        else if (questId == 25)
        {
            quest25Completed = true;
        }
        else if (questId == 26)
        {
            quest26Completed = true;
        }
        else if (questId == 27)
        {
            quest27Completed = true;
        } else if (questId == 28)
        {
            quest28Completed = true;
        }
    }

}
