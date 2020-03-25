using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject
{
    // line or decision
    private string type;
    private string dialogueLine;
    private string[] dialogueDecisions;

    public DialogueObject(string type, string dialogueLine, string[] dialogueDecisions)
    {
        this.type = type;
        this.dialogueLine = dialogueLine;
        this.dialogueDecisions = dialogueDecisions;
    }

    public DialogueObject()
    {
    }

    // Getter
    public string getType()
    {
        return this.type;
    }
    public string getDialogueLine()
    {
        return this.dialogueLine;
    }
    public string[] getDialogueDecisions()
    {
        return this.dialogueDecisions;
    }

    // Setter
    public void setType (string type)
    {
        this.type = type;
    }
    public void setDialogueLine(string dialogueLine)
    {
        this.dialogueLine = dialogueLine;
    }
    public void setDialogueDecisions(string[] dialogueDecisions)
    {
        this.dialogueDecisions = dialogueDecisions;
    }
}
