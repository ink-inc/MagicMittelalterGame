using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public int questId { get; set; }

    public QuestStage firstStage { get; set; }

    public QuestStage activeStage { get; set; }

    public QuestStage lastStageId { get; set; }

    //public List<QuestStage> allStages { get; set; }

    public Quest(int questId, QuestStage firstStage, QuestStage activeStage, QuestStage lastStageId)
    {
        this.questId = questId;
        this.firstStage = firstStage;
        this.activeStage = activeStage;
        this.lastStageId = lastStageId;
    }
}
