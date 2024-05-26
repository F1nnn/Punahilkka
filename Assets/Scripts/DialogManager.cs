using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    private void Start()
    {
        instance = this;
    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        //testi
        print($"{newLines[1].ToString()}, {isPerson}" );
    }
}
