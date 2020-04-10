using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRepository: MonoBehaviour
{
    public Questlog questlog;
    public Quest giveQuest(int questId)
    {
        foreach(Quest q in questlog.quests)
        {
            Debug.Log("b " +q.questId);
            if(q.questId == questId)
            {
                Debug.Log("a "+ q.activeStage.task);
                return q;
            }
        }
        QuestStage firstStage = giveStage(001);
        QuestStage finalStage = giveStage(003);
        return new Quest(questId, "TestQuest1", "In Progress", firstStage, firstStage, finalStage);
    }

    public QuestStage giveStage(int stageId)
    {
        if(stageId == 001)
        {
            return new QuestStage(stageId, 002, "Get a Life");
        }
        if(stageId == 002)
        {
            return new QuestStage(stageId, 003, "Sei kein Schmock");
        }
        else
        {
            return new QuestStage(stageId, -1, "Sei kein noch größerer Schmock");
        }
        
    }
}
