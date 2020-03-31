﻿using UnityEngine;

public class DialogueService
{
    private DialogueRepository dialogueRepository = new DialogueRepository();
    public DialogueObject GetDialogueObject(float id)
    {
        DialogueObject dialogueObject = dialogueRepository.ReadDialogueObjectById(id);
        foreach (int lineId in dialogueObject.dialogueLineIds)
        {
            dialogueObject
                .dialogueLines
                .Add(dialogueRepository
                .ReadDialogueLineById(lineId));
        }

        return dialogueObject;
    }
}