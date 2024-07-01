using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questNumber;
    public string lines;

    public QuestManager questManager;

    public bool isItemQuest;
    public string targetItem;
    public int itemToCollect;
    public int itemToCollectCount;


    void Update()
    {
        if (isItemQuest)
        {
            if (questManager.itemCollected == targetItem)
            {
                questManager.itemCollected = null;
                itemToCollectCount++;
            }
            if (itemToCollectCount >= itemToCollect)
            {
                EndQuest();
            }
        }
    }

    public void StartQuest()
    {
        questManager.ShowQuestText(lines[0]);
    }

    public void EndQuest()
    {
        questManager.ShowQuestText(lines[1]);
        questManager.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}
