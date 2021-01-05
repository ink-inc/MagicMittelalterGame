﻿namespace Interaction
{
    public class InteractableStartQuest : Interactable
    {
        public QuestHandler questHandler;
        public Questlog questlog;
        public QuestRepository questRepository;
        public int questId;

        public override void Interact(Interactor interactor)
        {
            questHandler.TryStartQuest(questId);
        }
    }
}