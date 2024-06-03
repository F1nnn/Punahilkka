using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    private string[] dialogLines;
    private int currentLine;
    private bool justStarted;

    [Header("CANVAS-DIALOG")]
    [SerializeField] private TMP_Text dialogText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject nameBox;

    private Mouse myMouse;


    private void Start()
    {
        instance = this;
        myMouse = Mouse.current;
    }

    private void Update()
    {
        if (justStarted && myMouse.rightButton.wasPressedThisFrame)
        {
            currentLine++;
            if (currentLine >= dialogLines.Length)
            {
                stopDialog();
            }
            else
            {
                CheckIfName();
                dialogText.text = dialogLines[currentLine];
            }
        }
    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;
        currentLine = 0;
        CheckIfName();
        nameBox.SetActive(isPerson);
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        justStarted = true;
    }

    public void stopDialog()
    {
        dialogBox.SetActive(false);
    }


    //onko henkilöllä nimi
    void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");

            currentLine++;
        }
    }
}
