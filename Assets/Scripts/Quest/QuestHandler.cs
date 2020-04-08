using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public Questlog questlog;

    public void StartQuest(Quest quest)
    {
        questlog.StartQuest(quest);
        quest.activeStage = quest.firstStage;
    }

    public void ProceedQuest(Quest quest)
    {
        if(quest.activeStage.stageId == quest.lastStageId.stageId)
        {
            FinishQuest(quest);
            return;
        }
        int nextQuestStageId = quest.activeStage.nextQuestStageID;
        //quest.activeStage = DATENBANKSCHNITTSTELLE.GETSTAGE(nextQuestStageId) TODO
    }

    public void FinishQuest(Quest quest)
    {
        questlog.FinishQuest(quest);
        //TODO:Automatically switch to another targetted quest or if none are open, say No Quests Active
    }
}
