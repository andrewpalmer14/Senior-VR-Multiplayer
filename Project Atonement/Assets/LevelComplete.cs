using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour {

    public string sceneName;
    public GameObject gate;
    public QuestGiver[] questGivers;

    private void OnTriggerEnter(Collider other)
    {
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
