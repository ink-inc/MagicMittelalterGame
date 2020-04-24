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
            if(q.questId == questId)
            {
                Logger.log("a "+ q.activeStage.task);
                return q;
            }
        }
        if(questId == 021)
        {
            QuestStage firstStage = giveStage(001);
            return new Quest(questId, "TestQuest1", "In Progress", firstStage, firstStage, false);
        }
        else if(questId == 022)
        {
            QuestStage firstStage = giveStage(006);
            return new Quest(questId, "TestQuest2", "In Progress", firstStage, firstStage, false);
        }
        else if(questId == 023)
        {
            QuestStage firstStage = giveStage(007);
            return new Quest(questId, "TestQuest3", "In Progress", firstStage, firstStage, false);
        }
        else
        {
            QuestStage firstStage = giveStage(008);
            return new Quest(questId, "Generic Test Quest", "In Progress", firstStage, firstStage, false);
        }
        
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
            return new QuestStage(stageId, nextStages, "Finished Quest with Decision 1");
        }
        else if(stageId == 005)
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Finished Quest with Decision 2");
        }
        else if (stageId == 006)
        {
            int[,] nextStages = new int[1, 2] { { 016, 008 } };
            return new QuestStage(stageId, nextStages, "Quest 2 Stage 1");
        }
        else if(stageId == 007)
        {
            int[,] nextStages = new int[1, 2] { { 017, 009 } };
            return new QuestStage(stageId, nextStages, "Quest 3 Stage 1");
        }
        else if(stageId == 008)
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Quest 2 Stage 2");
        }
        else if(stageId == 009)
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Quest 3 Stage 2");
        }
        else
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Generic Quest Stage");
        }

    }
}
