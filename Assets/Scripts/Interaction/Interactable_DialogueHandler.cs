using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_DialogueHandler : Interactable
{
    public int id;
    public DialogueHandler dialogueHandler;
    public override void interact()
    {
        dialogueHandler.StartDialogue(id);
    }
}