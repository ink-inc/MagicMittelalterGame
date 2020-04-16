using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/Health")]
    public class InteractableHealth : Interactable
    {
        public int value;

        public override void Interact(Interactor interactor)
        {
            var playerProp = interactor.GetComponent<PlayerProperties>();
            playerProp.Heal(value); //changes players current health
        }
    }
}