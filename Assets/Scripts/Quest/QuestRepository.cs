using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRepository: MonoBehaviour
{
    public Questlog questlog;


    public Quest readQuestFromDB(int questID)
    {
        QuestObjectDB questDB = new QuestObjectDB();
        System.Data.IDataReader reader = questDB.getDataById(questID);
        QuestStage firstStage = readQuestStageFromDB(int.Parse(reader[2].ToString()));
        bool isTargetted = true;
        Quest quest = new Quest(int.Parse(string.Format("{0}", reader[0])), string.Format("{0}", reader[1]), "In Progress",firstStage, firstStage, isTargetted);
        questDB.close();
        return quest;
    }


    public QuestStage readQuestStageFromDB(int stageID)
    {
        QuestStageDB stageDB = new QuestStageDB();
        System.Data.IDataReader reader = stageDB.getDataById(stageID);
        string nextIDs = string.Format("{0}", reader[2]);
        string[] idList = nextIDs.Split('%');
        int[,] list = new int[idList.Length - 1, 2];
        for (int i = 0; i < idList.Length-1; i++)
        {
            string[] row  = idList[i].Split(';');
            for(int j = 0; j<row.Length; j++)
            {
                int.TryParse(row[j], out list[i,j]);
                Logger.log(list[i, j] + "|" + i + "|"+ j);
            }
        }
        QuestStage stage = new QuestStage(int.Parse(string.Format("{0}", reader[0])), list, string.Format("{0}", reader[1]));
        return stage;
    }


    /*public Quest GiveQuest(int questId)
    {
        foreach(Quest q in questlog.quests)
        {
            if(q.questId == questId)
            {
                Logger.log("a "+ q.activeStage.task);
                return q;
            }
        }
        if(questId == 21)
        {
            QuestStage firstStage = GiveStage(1);
            return new Quest(questId, "TestQuest1", "In Progress", firstStage, firstStage, false);
        }
        else if(questId == 22)
        {
            QuestStage firstStage = GiveStage(6);
            return new Quest(questId, "TestQuest2", "In Progress", firstStage, firstStage, false);
        }
        else if(questId == 23)
        {
            QuestStage firstStage = GiveStage(7);
            return new Quest(questId, "TestQuest3", "In Progress", firstStage, firstStage, false);
        }
        else
        {
            QuestStage firstStage = GiveStage(8);
            return new Quest(questId, "Generic Test Quest", "In Progress", firstStage, firstStage, false);
        }
        
    }*/

    /*public QuestStage GiveStage(int stageId)
    {
        if(stageId == 1)
        {
            int[,] nextStages = new int[2, 2] {{12,2},{13,3}};
            return new QuestStage(stageId, nextStages, "Stufe 1");
        }
        else if(stageId == 2)
        {
            int[,] nextStages = new int[1, 2] { { 14, 4 } };
            return new QuestStage(stageId, nextStages, "Stufe 2 Decision 1");
        }
        else if(stageId == 3)
        {
            int[,] nextStages = new int[1, 2] { { 15, 5 } };
            return new QuestStage(stageId, nextStages, "Stufe 2 Decision 2");
        }
        else if(stageId == 4)
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Finished Quest with Decision 1");
        }
        else if(stageId == 5)
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Finished Quest with Decision 2");
        }
        else if (stageId == 6)
        {
            int[,] nextStages = new int[1, 2] { { 16, 8 } };
            return new QuestStage(stageId, nextStages, "Quest 2 Stage 1");
        }
        else if(stageId == 7)
        {
            int[,] nextStages = new int[1, 2] { { 17, 9 } };
            return new QuestStage(stageId, nextStages, "Quest 3 Stage 1");
        }
        else if(stageId == 8)
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Quest 2 Stage 2");
        }
        else if(stageId == 9)
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Quest 3 Stage 2");
        }
        else
        {
            int[,] nextStages = new int[1, 2] { { -1, -1 } };
            return new QuestStage(stageId, nextStages, "Generic Quest Stage");
        }

    }*/
}
