using System.Collections.Generic;

namespace Quest
{
    public class Quest
    {

        public string questName { get; set; }

        public string status { get; set; }
        public int questId { get; set; }

        public bool isTargetted { get; set; }

        public QuestStage firstStage { get; set; }

        public QuestStage activeStage { get; set; }

        public List<QuestStage> passedStages = new List<QuestStage>();

        public Quest(int questId, string questName, string status, QuestStage firstStage, QuestStage activeStage, bool isTargetted)
        {
            this.questId = questId;
            this.questName = questName;
            this.status = status;
            this.firstStage = firstStage;
            this.activeStage = activeStage;
            this.isTargetted = isTargetted;
        }
    }
}
