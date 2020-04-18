using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/Health")]
    public class InteractableHealth : Interactable
    {
        public int value;

        public override void Interact(Interactor interactor)
        {
            var playerProperties = interactor.GetComponent<PlayerProperties>();
            playerProperties.Heal(value); //changes players current health
        }
    }
}