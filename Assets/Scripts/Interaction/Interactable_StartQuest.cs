using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_StartQuest : Interactable
{
    public QuestHandler questHandler;
    public QuestRepository questRepository = new QuestRepository();
    public override void interact()
    {
        questHandler.StartQuest(001);
        Debug.Log("Quest given");
    }
}
