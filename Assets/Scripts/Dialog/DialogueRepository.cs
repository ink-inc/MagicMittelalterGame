using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogueRepository
{
    public List<DialogueObject> ReadData(string path)
    {
        List<DialogueObject> dialogueObjects = new List<DialogueObject>();

        StreamReader reader = new StreamReader(path);

        DialogueObject d = new DialogueObject();
        while (reader.EndOfStream == false)
        {
            string line = reader.ReadLine();
            dialogueObjects.Add(interpretLine(line, reader));
        }

        return dialogueObjects;
    }
    public DialogueObject interpretLine(string line, StreamReader reader)
    {
        string substring = line.Substring(0, 4);

        DialogueObject dialogueObject = new DialogueObject();
        dialogueObject.setType(substring);
        dialogueObject.setDialogueLine(line.Substring(6));

        if (substring.Equals("Dcsn"))
        {
            string[] decisions = { reader.ReadLine(), reader.ReadLine(), reader.ReadLine() };
            dialogueObject.setDialogueDecisions(decisions);
        }

        return dialogueObject;
    }
}
