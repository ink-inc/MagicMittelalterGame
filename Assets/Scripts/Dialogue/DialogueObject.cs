using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject
{
    public int id { get; set; } 
    public string type { get; set; } // line or decision
    public int[] dialogueLineIds { get; set; }
    public List<DialogueLine> dialogueLines { get; set; }

    public DialogueObject() { }

    public DialogueObject(int id, string type, int[] dialogueLineIds)
    {
        this.id = id;
        this.type = type;
        this.dialogueLineIds = dialogueLineIds;
        dialogueLines = new List<DialogueLine>();
    }
}
