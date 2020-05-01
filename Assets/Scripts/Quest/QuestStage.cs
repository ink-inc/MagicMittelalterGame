namespace Quest
{
    public class QuestStage
    {
        public int stageId { get; set; }

        public string task { get; set; }

        public int[,] nextQuestStagesID { get; set; } // [x][0] = InteractableID when taken option x, [x][1] = ID of next stage when taken option x
        public QuestStage(int stageId, int[,] nextQuestStagesID, string task)
        {
            this.stageId = stageId;
            this.nextQuestStagesID = nextQuestStagesID;
            this.task = task;
        }
    }
}
