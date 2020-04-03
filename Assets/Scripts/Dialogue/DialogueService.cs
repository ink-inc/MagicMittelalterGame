using UnityEngine;

public class DialogueService
{
    private DialogueRepository dialogueRepository = new DialogueRepository();
    public DialogueObject GetDialogueObject(int id)
    {
        DialogueObject dialogueObject = dialogueRepository.ReadDialogueObjectById(id);
        if (!dialogueObject.type.Equals("End"))
        {
            foreach (int lineId in dialogueObject.dialogueLineIds)
            {
                dialogueObject
                    .dialogueLines
                    .Add(dialogueRepository
                    .ReadDialogueLineById(lineId));
            }
        }
        

        return dialogueObject;
    }
}
