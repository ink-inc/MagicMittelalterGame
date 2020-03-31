using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System;

public class DialogueHandler : MonoBehaviour
{
    public GameObject HUD;
    public GameObject dialogueInterface;
    public GameObject lineText;
    public GameObject decisionParent;
    public GameObject decisionButtonPrefab;

    private DialogueObject dialogueObject = new DialogueObject();
       
    private DialogueService dialogueService = new DialogueService();
    private int decision;

    public void StartDialogue(float starterId)
    {
        HUD.SetActive(false);
        dialogueInterface.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        dialogueObject = dialogueService.GetDialogueObject(starterId);
        StartCoroutine(DialogueLoop());
    }

    private IEnumerator DialogueLoop()
    {
        bool shouldTheLoopRun = true;
        float nextDialogueObjectId = -1;
        while (shouldTheLoopRun) 
        {
            decision = -1;
            if (dialogueObject.type.Equals("Line"))
            {
                SayLine();
                PlayAnimation();
                PresentLine(dialogueObject.dialogueLines[0].line);
                yield return new WaitForSeconds(1);
                nextDialogueObjectId = dialogueObject.dialogueLines[0].nextDialogueObjectId;
            } else if (dialogueObject.type.Equals("Decision"))
            {
                PresentDecisions(dialogueObject.dialogueLines);
                yield return new WaitUntil(() => decision > -1);

                nextDialogueObjectId = dialogueObject
                    .dialogueLines[decision]
                    .nextDialogueObjectId;
            } else if (dialogueObject.type.Equals("End")) {
                shouldTheLoopRun = false;
            }
            dialogueObject = dialogueService.GetDialogueObject(nextDialogueObjectId);
        }
    }

    private void PresentLine(string line)
    {
        TextMeshProUGUI textField = dialogueInterface.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textField.text = line;
    }

    private void PresentDecisions(List<DialogueLine> decisions)
    {
        decisionParent.SetActive(true);
        int i = 0;
        foreach (DialogueLine line in decisions)
        {                 
            GameObject newDecisionButton = Instantiate(decisionButtonPrefab, decisionParent.transform); // Create Button instance
            newDecisionButton.name = "Decision#" + i; // Set name for editor clarity
            Button buttonComponent = newDecisionButton.GetComponent<Button>();
            int ii = i;
            buttonComponent.onClick.AddListener(delegate () { ReceiveDecisionInput(ii); }); // Add button click handler
            newDecisionButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = line.line; // Display decision text
            i++;
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

        while (decisionParent.transform.childCount > 0)
        {
            Transform child = decisionParent.transform.GetChild(0);
            child.SetParent(null);
            Destroy(child.gameObject);
        }
        decisionParent.SetActive(false);
    }
}
