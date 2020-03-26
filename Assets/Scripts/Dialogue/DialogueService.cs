using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueService
{
    private DialogueRepository dialogueRepository = new DialogueRepository();
    public List<DialogueObject> GetDialogueObjects(int id)
    {
        string path = "TestDialog.txt";

        return dialogueRepository.ReadData(path);
    }
}
