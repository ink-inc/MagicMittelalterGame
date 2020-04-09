using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{

    public string questName { get; set; }

    public string status { get; set; }
    public int questId { get; set; }

    public QuestStage firstStage { get; set; }

    public QuestStage activeStage { get; set; }

    public QuestStage lastStageId { get; set; }

    //public List<QuestStage> allStages { get; set; }

    public Quest(int questId, string questName, string status, QuestStage firstStage, QuestStage activeStage, QuestStage lastStageId)
    {
        this.questId = questId;
        this.questName = questName;
        this.status = status;
        this.firstStage = firstStage;
        this.activeStage = activeStage;
        this.lastStageId = lastStageId;
    }
}
