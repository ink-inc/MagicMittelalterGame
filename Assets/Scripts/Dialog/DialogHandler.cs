using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogHandler : MonoBehaviour
{
    public GameObject dialogInterface;
    private float DialogOption = -1;

    private List<DialogObject> dialogObjects;

    public void StartDialog(int id)
    {
        DialogService dialogService = new DialogService();
        dialogObjects = dialogService.GetDialogObjects(id);

        dialogInterface.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        StartCoroutine(DialogLoop());
    }

    private IEnumerator DialogLoop()
    {
        foreach(DialogObject dialogObject in dialogObjects)
        {
            bool a = true;
            PresentText(dialogObject);
            SayLine(); //Empty Call
            PlayAnimation(); //Empty Call
            
            if (dialogObject.getType().Equals("Dcsn"))
            {
                PresentDecision(dialogObject);
                yield return new WaitUntil(() => DialogOption != -1);
            } else if (dialogObject.getType().Equals("Line"))
            {
                yield return new WaitForSeconds(1);
            }
        }

        EndDialogue();
    }

    private void PresentText(DialogObject dialogObject)
    {
        TextMeshProUGUI textField = dialogInterface.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textField.text = dialogObject.getDialogLine();
    }

    private void SayLine()
    {

    }

    private void PlayAnimation()
    {
        // play the speaking animation that is attached to this character
    }

    private void PresentDecision(DialogObject dialogObject)
    {
        dialogInterface.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);

        TextMeshProUGUI option1 = dialogInterface.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI option2 = dialogInterface.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI option3 = dialogInterface.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

        option1.text = dialogObject.getDialogDecisions()[0];
        option2.text = dialogObject.getDialogDecisions()[1];
        option3.text = dialogObject.getDialogDecisions()[2];
    }

    private void EndDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dialogInterface.SetActive(false);
    }

    public void decision1()
    {
        DialogOption = 0f;
        dialogInterface.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
    }
    public void decision2()
    {
        DialogOption = 1f;
        dialogInterface.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
    }
    public void decision3()
    {
        DialogOption = 2f;
        dialogInterface.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
    }
}
