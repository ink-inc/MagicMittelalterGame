using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour
{
    public GameObject HUD;
    public GameObject dialogueInterface;
    public GameObject lineText;
    public GameObject decisionParent;
    public GameObject decisionButtonPrefab;

    private List<DialogueObject> dialogueObjects;
       
    private DialogueService dialogueService = new DialogueService();
    private int decision;

    public void StartDialogue(float starterId)
    {
        dialogueObjects.Add(dialogueService.GetDialogueObject(starterId));
        StartCoroutine(DialogueLoop());
    }

    private IEnumerator DialogueLoop()
    {
        float nextDialogueObjectId;
        foreach (DialogueObject dialogueObject in dialogueObjects)
        {
            decision = -1;
            if (dialogueObject.type.Equals("Line"))
            {
                SayLine();
                PlayAnimation();
                PresentLine(dialogueObject.dialogueLines[0].line);
                yield return new WaitForSeconds(2);
                nextDialogueObjectId = dialogueObject.dialogueLines[0].nextDialogueObjectId;
            } else if (dialogueObject.type.Equals("Decision"))
            {
                PresentDecisions(dialogueObject.dialogueLines);
                yield return new WaitUntil(() => decision > -1);
                nextDialogueObjectId = dialogueObject.dialogueLines[decision].nextDialogueObjectId;
            } else
            {
                throw new System.Exception(); 
            }
            DialogueObject nextDialogueObject = dialogueService.GetDialogueObject(nextDialogueObjectId);
            dialogueObjects.Add(nextDialogueObject);
        }
    }

    private void PresentLine(string line)
    {
        TextMeshProUGUI textField = dialogueInterface.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textField.text = line;
    }

    private void PresentDecisions(List<DialogueLine> decisions)
    {
        int i = 0;
        foreach (DialogueLine line in decisions)
        {
            i++;
            GameObject newDecisionButton = Instantiate(decisionButtonPrefab, decisionParent.transform); // Create Button instance
            newDecisionButton.name = "Decision#" + i; // Set name for editor clarity
            Button buttonComponent = newDecisionButton.GetComponent<Button>();
            buttonComponent.onClick.AddListener(delegate () { ReceiveDecisionInput(i); }); // Add button click handler
            newDecisionButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = line.line; // Display decision text
        }
    }

    private void SayLine()
    {
        // Audio output
    }

    private void PlayAnimation()
    {
        // Animation output
    }

    public void ReceiveDecisionInput(int dec)
    {
        decision = dec;
    }
}
