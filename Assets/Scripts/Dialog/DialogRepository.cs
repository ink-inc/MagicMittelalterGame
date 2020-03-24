using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogRepository
{
    public List<DialogObject> ReadData(string path)
    {
        List<DialogObject> dialogObjects = new List<DialogObject>();

        StreamReader reader = new StreamReader(path);

        DialogObject d = new DialogObject();
        while (reader.EndOfStream == false)
        {
            string line = reader.ReadLine();
            dialogObjects.Add(interpretLine(line, reader));
        }

        return dialogObjects;
    }
    public DialogObject interpretLine(string line, StreamReader reader)
    {
        string substring = line.Substring(0, 4);

        DialogObject dialogObject = new DialogObject();
        dialogObject.setType(substring);
        dialogObject.setDialogLine(line.Substring(6));

        if (substring.Equals("Dcsn"))
        {
            string[] decisions = { reader.ReadLine(), reader.ReadLine(), reader.ReadLine() };
            dialogObject.setdialogDecisions(decisions);
        }

        return dialogObject;
    }
}
