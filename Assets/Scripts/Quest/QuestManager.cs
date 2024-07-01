using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] quests;

    public bool[] questCompleted;

    public string itemCollected;




    void Start()
    {
        questCompleted = new bool[questCompleted.Length];
    }

    public void ShowQuestText(string questTask)
    {
        string[] oneLine = new string[1];
        oneLine[0] = questTask;

        DialogManager.instance.ShowDialog(oneLine, false);
    }
}
