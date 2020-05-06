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
            playerProp.SetHealth(Mathf.Clamp(playerProp.GetHealth() + value, 0, playerProp.GetMaxHealth())); //changes players current health
        }
    }
}