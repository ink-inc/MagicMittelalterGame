using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Interactable_StartQuest : Interactable
    {
        public QuestHandler questHandler;
        public Questlog questlog;
        public QuestRepository questRepository;
        public int questId;
        public override void Interact(Interactor interactor )
        {
            foreach (Quest q in questlog.quests)
            {
                if (q.questId == questId)
                {
                    return;
                }
            }
            questHandler.StartQuest(questId);
        }
    }
}
