using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : MonoBehaviour
{
    //dialog tekstit
    [SerializeField] private string[] lines;

    [field:SerializeField] public bool IsPerson { get; private set; }
    public bool CanDialogActivated { get; private set; }
    public bool IsDialogStarted { get; private set; }


    private void Update()
    {
        if (CanDialogActivated)
        {
            //n‰ytt‰‰ dialogin
            DialogManager.instance.ShowDialog(lines, IsPerson);
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
        if (collision.CompareTag("Player"))
        {
            CanDialogActivated = false;
        }
    }

}
