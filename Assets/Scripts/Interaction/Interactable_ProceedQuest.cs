using UnityEngine;

namespace Interaction
{
    public class Interactable_ProceedQuest : Interactable
    {
        public QuestHandler questHandler;
        public Questlog questlog;
        public GameObject questMarker;
        public int interactableId;

        // HOW IT WORKS: Every interactable has its own unique id, every queststage has an array, in which to every option x 
        // an interactableID ([x][0]) and the next stage ([x][1]) are distributed. This interactable searches the entire questlog
        // for every quest and their current stage, if this interactable id is distributed to a next stage. If this is the case,
        // ProceedQuest is called to advance the respective quest into that stage

        public override void Interact(Interactor interactor)
        {
            foreach (Quest quest in questlog.quests.ToArray())   // Iterating over copy of list; removing quests while in for loop causes problems
            {
                if(quest.status != "Finished")
                {
                    for (int i = 0; i < quest.activeStage.nextQuestStagesID.GetLength(0); i++)
                    {
                        if (quest.activeStage.nextQuestStagesID[i, 0] == interactableId)
                        {
                            int nextStageId = quest.activeStage.nextQuestStagesID[i, 1];
                            questHandler.ProceedQuest(quest.questId, nextStageId);
                        }
                    }
                } 
            }
        }
    }
}