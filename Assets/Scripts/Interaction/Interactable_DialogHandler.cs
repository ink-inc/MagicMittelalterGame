using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_DialogHandler : Interactable
{
    public int id;
    public DialogHandler dialogHandler;
    public override void interact()
    {
        dialogHandler.StartDialog(id);
    }
}