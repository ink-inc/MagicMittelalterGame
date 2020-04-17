using Player;
using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/Health")]
    public class InteractableHealth : Interactable
    {
        public int value;

        public override void Interact(Interactor interactor)
        {
            var health = interactor.GetComponent<Health>();
            health.Heal(value); //changes players current health
        }
    }
}