using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_ProceedQuest : Interactable
{
    public QuestHandler questHandler;
    public int questId = 001;
    public override void interact()
    {
        questHandler.ProceedQuest(questId);
    }
}
