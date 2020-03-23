using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogObject
{
    private string type; // line or decision
    private string dialogLine;
    private string[] dialogDecisions;

    // Getter
    public string GetType()
    {
        return this.type;
    }
    public string GetDialogLine()
    {
        return this.dialogLine;
    }
    public string[] GetDialogDecisions()
    {
        return dialogDecisions;
    }

    // Setter
    public void SetType(string type)
    {
        this.type = type;
    }
    public void SetDialogLine(string dialogLine)
    {
        this.dialogLine = dialogLine;
    }
    public void SetDialogDecisions(string[] dialogDecisions)
    {
        this.dialogDecisions = dialogDecisions;
    }
}
