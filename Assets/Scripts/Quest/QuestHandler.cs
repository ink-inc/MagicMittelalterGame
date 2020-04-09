using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public Questlog questlog;
    public QuestRepository questRepository = new QuestRepository();

    public void StartQuest(int questId)
    {
        Quest quest = questRepository.giveQuest(questId);
        questlog.StartQuest(quest);
        quest.activeStage = quest.firstStage;
    }

    public void ProceedQuest(int questId)
    {
        Quest quest = questRepository.giveQuest(questId);
        if(quest.activeStage.stageId == quest.lastStageId.stageId)  //Beende die Quest, falls die eben abgeschlossene Aufgabe die Letzte war
        {
            FinishQuest(questId);
            return;
        }
        int nextQuestStageId = quest.activeStage.nextQuestStageID;
        quest.activeStage = questRepository.giveStage(nextQuestStageId); //WIP
    }

    public void FinishQuest(int questId)
    {
        Quest quest = questRepository.giveQuest(questId);
        questlog.FinishQuest(quest);
        //TODO:Automatically switch to another targetted quest or if none are open, say No Quests Active
    }
}
