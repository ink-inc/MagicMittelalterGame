using Sounds.Manager;

[AddComponentMenu("Interaction/Interactable/DialogStarter")]
public class Interactable_DialogueHandler : Interactable
{
    public int id;
    public DialogueHandler dialogueHandler;

    public override void interact()
    {
        CharacterSounds characterSounds = GetComponent<CharacterSounds>();
        dialogueHandler.StartDialogue(id, characterSounds);
    }
}