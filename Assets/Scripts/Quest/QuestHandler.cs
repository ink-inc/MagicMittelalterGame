﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public Questlog questlog;
    public QuestRepository questRepository;

    public void StartQuest(int questId)
    {
        Quest quest = questRepository.giveQuest(questId);
        questlog.StartQuest(quest);
        questlog.moveToFirst(quest);
        quest.activeStage = quest.firstStage;
        quest.status = "In Progress";
        Logger.log(quest.activeStage.task);
    }

    public void ProceedQuest(int questId, int nextStageId)
    {

        Quest quest = questlog.giveQuest(questId);
        QuestStage nextStage = questRepository.giveStage(nextStageId);
        if (nextStage.nextQuestStagesID[0,0] == -1)
        {
            FinishQuest(questId);
            return;
        }
        quest.activeStage = nextStage;
        Logger.log(quest.activeStage.task);
        questlog.moveToFirst(quest);

    }

    public void FinishQuest(int questId)
    {
        Quest quest = questlog.giveQuest(questId); 
        Logger.log("Quest Finished");
        quest.status = "Finished";
        //questlog.FinishQuest(quest);
    }
}
