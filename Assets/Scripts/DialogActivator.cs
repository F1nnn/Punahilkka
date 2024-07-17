using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogActivator : MonoBehaviour
{
    //dialog tekstit
    [SerializeField] private string[] lines;

    [field:SerializeField] public bool IsPerson { get; private set; }

    public bool CanDialogActivated { get; private set; }
    public bool IsDialogStarted { get; private set; }


    //private bool canActivate;
    public bool isQuest;
    private QuestManager questManager;
    public int questNumber;


    private Mouse myMouse;




    private void Start()
    {
        myMouse = Mouse.current;
        questManager = FindObjectOfType<QuestManager>();
    }


    private void Update()
    {
        if (CanDialogActivated && myMouse.leftButton.wasPressedThisFrame && !IsDialogStarted)
        {
            //n‰ytt‰‰ dialogin
            DialogManager.instance.ShowDialog(lines, IsPerson);
            IsDialogStarted = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CanDialogActivated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //canActivate = false;

        if (isQuest)
        {
            StartQuest();
        }

        if (IsDialogStarted)
        {
            gameObject.SetActive(false);
        }
    }

    void StartQuest()
    {
        questManager.quests[questNumber].gameObject.SetActive(true);
        questManager.quests[questNumber].StartQuest();

        gameObject.SetActive(false);
    }

}
