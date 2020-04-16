using Sounds.Manager;
using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/DialogueStarter")]
    public class InteractableDialogueStarter : Interactable
    {
        public int dialogueId;
        public DialogueHandler dialogueHandler;
        public CharacterSounds characterSounds;

        private void Start()
        {
            if (characterSounds == null)
            {
                characterSounds = GetComponent<CharacterSounds>();
                Logger.logWarning("Interactable characterSounds is missing and has been automatically assigned. Please assign it manually.");
            }
        }

        public override void Interact(Interactor interactor)
        {
            dialogueHandler.StartDialogue(dialogueId, characterSounds);
        }
    }
}