using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_StartQuest : Interactable
{
    public QuestHandler questHandler;
    public Questlog questlog;
    public QuestRepository questRepository = new QuestRepository();
    public int questId = 001;
    public override void interact()
    {
        foreach(Quest q in questlog.quests)
        {
            if(q.questId == questId)
            {
                return;
            }
        }
        questHandler.StartQuest(questId);
    }
}
