using System.Linq;
using UnityEngine;
public class DialogueRepository
{
    public void ReadData() { // just a method for testing
                
    }

    public DialogueObject ReadDialogueObjectById(int id) {
        // Database call
        DialogueObjectDB dialogueObjectDB = new DialogueObjectDB();

        System.Data.IDataReader reader = dialogueObjectDB.getDataById(id);

        DialogueObject dialogueObject = new DialogueObject(
            int.Parse(string.Format("{0}", reader[0])),
            string.Format("{0}", reader[1]),
            string.Format("{0}", reader[2]).Split(',').Select(int.Parse).ToArray());

        dialogueObjectDB.close();

        return dialogueObject;
    }

    public DialogueLine ReadDialogueLineById(int id)
    {
        DialogueLineDB dialogueLineDB = new DialogueLineDB();

        System.Data.IDataReader reader = dialogueLineDB.getDataById(id);

        DialogueLine dialogueLine = new DialogueLine(
            int.Parse(string.Format("{0}", reader[0])),
            string.Format("{0}", reader[1]),
            int.Parse(string.Format("{0}", reader[2])));

        dialogueLineDB.close();

        return dialogueLine;
    }
}
