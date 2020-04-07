using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public int questId { get; set; }

    public int firstStageId { get; set; }

    public int activeStageId { get; set; }

    public Quest(int questId, int firstStageId, int activeStageId)
    {
        this.questId = questId;
        this.firstStageId = firstStageId;
        this.activeStageId = activeStageId;
    }
}
