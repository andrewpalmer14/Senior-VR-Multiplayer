using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public string sceneName;
    public GameObject gate;
    public QuestGiver[] questGivers;
    public QuestManager questManager;

    private void OnTriggerEnter(Collider other)
    {
        questManager.DestroyQuestGivers();
        questManager.questGivers = null;
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        foreach(QuestGiver questGiver in questGivers)
        {
            if (!questGiver.QuestIsCompleted())
            {
                return;
            }
        }
        Destroy(gate);
    }
}
