using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_DialogHandler : Interactable
{
    public int id;
    public override void interact()
    {
        DialogHandler dialogHandler = new DialogHandler();
        dialogHandler.StartDialog(id);
    }
}