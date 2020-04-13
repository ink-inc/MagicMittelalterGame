using System.Collections;
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
        quest.activeStage = quest.firstStage;
        quest.status = "In Progress";
        Debug.Log(quest.activeStage.task);
    }

    public void ProceedQuest(int questId, int nextStageId)
    {
        Quest quest = questlog.giveQuest(questId);
        QuestStage nextStage = questRepository.giveStage(nextStageId);
        if(nextStage.nextQuestStagesID[0,0] == -1)
        {
            FinishQuest(questId);
            return;
        }
        quest.activeStage = nextStage; //WIP
        Debug.Log(quest.activeStage.task);
    }

    public void FinishQuest(int questId)
    {
        Quest quest = questlog.giveQuest(questId); 
        Debug.Log("Quest Finished");
        quest.status = "Finished";
        questlog.FinishQuest(quest);
    }
}
