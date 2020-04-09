using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_StartQuest : Interactable
{
    public QuestHandler questHandler;
    public QuestRepository questRepository = new QuestRepository();
    public override void interact()
    {
        Quest quest = questRepository.giveQuest(001);
        questHandler.StartQuest(quest);
        Debug.Log("Quest given");
    }
}
