using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_StartUnlimitedQuests : Interactable
{
    public QuestHandler questHandler;
    public override void interact()
    {
        System.Random random = new System.Random();
        int id = random.Next(10,1000);
        questHandler.StartQuest(id);
        Logger.log(""+id);
    }
}
