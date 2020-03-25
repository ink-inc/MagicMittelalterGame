using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public GameObject dialogueInterface;
    public GameObject HUD;
    private float DialogueOption = -1;

    private List<DialogueObject> dialogueObjects;

    public void StartDialogue(int id)
    {
        DialogueService dialogueService = new DialogueService();
        dialogueObjects = dialogueService.GetDialogueObjects(id);

        HUD.SetActive(false);
        dialogueInterface.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        StartCoroutine(DialogueLoop());
    }

    private IEnumerator DialogueLoop()
    {
        foreach(DialogueObject dialogueObject in dialogueObjects)
        {
            bool a = true;
            PresentText(dialogueObject);
            SayLine(); //Empty Call
            PlayAnimation(); //Empty Call
            
            if (dialogueObject.getType().Equals("Dcsn"))
            {
                PresentDecision(dialogueObject);
                yield return new WaitUntil(() => DialogueOption != -1);
            } else if (dialogueObject.getType().Equals("Line"))
            {
                yield return new WaitForSeconds(1);
            }
        }

        EndDialogue();
    }

    private void PresentText(DialogueObject dialogueObject)
    {
        TextMeshProUGUI textField = dialogueInterface.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textField.text = dialogueObject.getDialogueLine();
    }

    private void SayLine()
    {

    }

    private void PlayAnimation()
    {
        // play the speaking animation that is attached to this character
    }

    private void PresentDecision(DialogueObject dialogObject)
    {
        dialogueInterface.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);

        TextMeshProUGUI option1 = dialogueInterface.transform.GetChild(0).GetChild(1).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI option2 = dialogueInterface.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI option3 = dialogueInterface.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();

        option1.text = dialogObject.getDialogueDecisions()[0];
        option2.text = dialogObject.getDialogueDecisions()[1];
        option3.text = dialogObject.getDialogueDecisions()[2];
    }

    private void EndDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        dialogueInterface.SetActive(false);
        HUD.SetActive(true);
    }

    public void decision1()
    {
        DialogueOption = 0f;
        dialogueInterface.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
    }
    public void decision2()
    {
        DialogueOption = 1f;
        dialogueInterface.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
    }
    public void decision3()
    {
        DialogueOption = 2f;
        dialogueInterface.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
    }
}
