using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/DialogueStarter")]
    public class InteractableDialogueStarter : Interactable
    {
        public int dialogueId;
        public DialogueHandler dialogueHandler;

        public override void Interact(Interactor interactor)
        {
            dialogueHandler.StartDialogue(dialogueId);
        }
    }
}