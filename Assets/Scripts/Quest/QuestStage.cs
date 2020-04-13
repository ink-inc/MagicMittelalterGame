using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStage
{
    public int stageId { get; set; }

    public string task { get; set; }

    public int nextQuestStageID { get; set; }   //TODO Remove, use nextQuestStagesID instead

    public int[,] nextQuestStagesID { get; set; } //[x][0] = InteractableID when taken option x, [x][1] = ID of next stage when taken option x
                                                    //TODO Fill Repository with mocked nextQuestStagesID
    public QuestStage(int stageId, int[,] nextQuestStagesID, string task)
    {
        this.stageId = stageId;
        this.nextQuestStagesID = nextQuestStagesID;
        this.task = task;
    }
}
