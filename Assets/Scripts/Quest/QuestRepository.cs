using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRepository
{
    public Quest giveQuest(int id)
    {
        QuestStage firstStage = new QuestStage(001, 002, "Get a Life");
        QuestStage finalStage = new QuestStage(008, -1, "Defeat yo Mama");
        return new Quest(id, "TestQuest1", "In Progress", firstStage, firstStage, finalStage);
    }

    public QuestStage giveStage(int stageId)
    {
        return new QuestStage(stageId, stageId + 1, "Sei kein Schmock");
    }
}
