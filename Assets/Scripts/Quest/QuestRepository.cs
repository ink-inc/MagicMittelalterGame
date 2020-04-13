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
            int[,] nextStages = new int[2, 2] {{012,002},{013,003}};
            return new QuestStage(stageId, nextStages, "Stufe 1");
        }
        else if(stageId == 002)
        {
            int[,] nextStages = new int[1, 2] { { 014, 004 } };
            return new QuestStage(stageId, nextStages, "Stufe 2 Decision 1");
        }
        else if(stageId == 003)
        {
            int[,] nextStages = new int[1, 2] { { 015, 005 } };
            return new QuestStage(stageId, nextStages, "Stufe 2 Decision 2");
        }
        else if(stageId == 004)
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Stufe 3 Decision 1");
        }
        else
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Stufe 3 Decision 2");
        }
        
    }
}
