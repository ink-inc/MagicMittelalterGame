using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogObject
{
    // line or decision
    private string type;
    private string dialogLine;
    private string[] dialogDecisions;

    public DialogObject(string type, string dialogLine, string[] dialogDecisions)
    {
        this.type = type;
        this.dialogLine = dialogLine;
        this.dialogDecisions = dialogDecisions;
    }

    public DialogObject()
    {
    }

    // Getter
    public string getType()
    {
        return this.type;
    }
    public string getDialogLine()
    {
        return this.dialogLine;
    }
    public string[] getDialogDecisions()
    {
        return this.dialogDecisions;
    }

    // Setter
    public void setType (string type)
    {
        this.type = type;
    }
    public void setDialogLine(string dialogLine)
    {
        this.dialogLine = dialogLine;
    }
    public void setdialogDecisions(string[] dialogDecisions)
    {
        this.dialogDecisions = dialogDecisions;
    }
}
