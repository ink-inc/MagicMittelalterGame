using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DialogService
{
    public List<DialogObject> GetDialogObjects(int id)
    {
        string path = "TestDialog.txt";

        StreamReader reader = new StreamReader(path);
        //Debug.Log(reader.ReadToEnd());

        while (reader.EndOfStream == false)
        {
            string line = reader.ReadLine();
            interpretLine(line, reader);
        }
        


        return new List<DialogObject>();
    }

    private DialogObject interpretLine(string line, StreamReader reader)
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

        return new DialogObject();
    }
}
