using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStage
{
    public int stageId { get; set; }

    public string task { get; set; }

    public int nextQuestStageID { get; set; }

    public QuestStage(int stageId, int nextQuestStageID, string task)
    {
        this.stageId = stageId;
        this.nextQuestStageID = nextQuestStageID;
        this.task = task;
    }
}
