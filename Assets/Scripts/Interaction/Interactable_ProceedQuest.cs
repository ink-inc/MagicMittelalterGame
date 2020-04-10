using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_ProceedQuest : Interactable
{
    public QuestHandler questHandler;
    public override void interact()
    {
        questHandler.ProceedQuest(001);
    }
}
