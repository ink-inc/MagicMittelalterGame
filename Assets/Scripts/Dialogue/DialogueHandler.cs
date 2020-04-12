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
    private int decisionLines = 0;
    private int decision;

    public void StartDialogue(int starterId)
    {
        HUD.SetActive(false);
        dialogueInterface.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        dialogueObject = dialogueService.GetDialogueObject(starterId);
        StartCoroutine(DialogueLoop());
    }

    public void DialogueEnd()
    {
        HUD.SetActive(true);
        dialogueInterface.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private IEnumerator DialogueLoop()
    {
        bool shouldTheLoopRun = true;
        int nextDialogueObjectId = -1;
        while (shouldTheLoopRun)
        {
            decision = -1;
            if (dialogueObject.type.Equals("Line"))
            {
                SayLine();
                PlayAnimation();
                PresentLine(dialogueObject.dialogueLines[0].line);

                yield return StartCoroutine(SkipOrPlayLine((dialogueObject.dialogueLines[0].line.Length * 50) + 500)); // Time in milliseconds

                nextDialogueObjectId = dialogueObject.dialogueLines[0].nextDialogueObjectId;
            }
            else if (dialogueObject.type.Equals("Decision"))
            {
                PresentDecisions(dialogueObject.dialogueLines);

                StartCoroutine(ReceiveDecisionInputByKeyboard());
                yield return new WaitUntil(() => decision > -1);

                nextDialogueObjectId = dialogueObject
                    .dialogueLines[decision]
                    .nextDialogueObjectId;
            }
            else if (dialogueObject.type.Equals("End"))
            {
                shouldTheLoopRun = false;
            }
            dialogueObject = dialogueService.GetDialogueObject(nextDialogueObjectId);
        }

        DialogueEnd();
    }

    private void PresentLine(string line)
    {
        TextMeshProUGUI textField = lineText.GetComponentInChildren<TextMeshProUGUI>();
        textField.text = line;
    }

    private IEnumerator SkipOrPlayLine(long waitTime)
    {
        long time = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        while (currentTime - time < waitTime)
        {
            currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            yield return new WaitForSeconds(0.00001f);
            if (Input.GetKeyDown("space"))
            {
                currentTime += waitTime;
            }
        }
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
        decisionLines = decisions.Count;
    }

    public void ReceiveDecisionInput(int dec)
    {
        decision = dec;

        ResetDecisionParent();
    }

    private IEnumerator ReceiveDecisionInputByKeyboard()
    {
        KeyCode[] keyCodes = {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9,
        };

        while (decision < 0)
        {
            for (int i = 0; i < decisionLines; i++) {
                if (Input.GetKeyDown(keyCodes[i]))
                {
                    decision = i;

                    ResetDecisionParent();
                }
            }

            yield return new WaitForSeconds(0.001f);
        }
    }

    private void ResetDecisionParent()
    {
        while (decisionParent.transform.childCount > 0)
        {
            Transform child = decisionParent.transform.GetChild(0);
            child.SetParent(null);
            Destroy(child.gameObject);
        }
        decisionParent.SetActive(false);
    }

    private void SayLine()
    {
        // Audio output
    }

    private void PlayAnimation()
    {
        // Animation output
    }
}