using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueObject
{
    public float id { get; set; } 
    public string type { get; set; } // line or decision
    public float[] dialogueLineIds { get; set; }
    public List<DialogueLine> dialogueLines { get; set; }

    public DialogueObject() { }

    public DialogueObject(float id, string type, float [] dialogueLineIds)
    {
        this.id = id;
        this.type = type;
        this.dialogueLineIds = dialogueLineIds;
        dialogueLines = new List<DialogueLine>();
    }
}
