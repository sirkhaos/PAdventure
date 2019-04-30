using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questID;
    private QuestManager manager;

    public string startText, completeText;

    public bool needsItem;
    public string itemNeeded;

    public bool needsEnemy;
    public string enemyName;
    public int numberOfEnemies;
    private int enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (needsItem && manager.itemCollected.Equals(itemNeeded))
        {
            manager.itemCollected = null;
            CompleteQuest();
        }
        if(needsEnemy && manager.enemykelled.Equals(enemyName))
        {
            manager.enemykelled = null;
            enemiesKilled++;
            if (enemiesKilled >= numberOfEnemies)
            {
                CompleteQuest();
            }
        }
    }
    public void StartQuest()
    {
        manager = FindObjectOfType<QuestManager>();
        manager.ShowQuestText(startText);
    }
    public void CompleteQuest()
    {
        manager.ShowQuestText(completeText);
        manager.questCompleted[questID] = true;
        gameObject.SetActive(false); //esto es para no poder repetir la quest
    }
}
