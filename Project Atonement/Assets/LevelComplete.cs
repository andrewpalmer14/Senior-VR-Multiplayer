using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public string sceneName;
    public GameObject gate;
    public QuestGiver[] questGivers;
    private QuestManager questManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        questManager.DestroyQuestGivers();
        questManager.questGivers = null;
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if (questManager == null)
        {
            questManager = FindObjectOfType<QuestManager>();//GameObject.FindObjectOfType<QuestManager>();
            print("found quest manager");
        }
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
