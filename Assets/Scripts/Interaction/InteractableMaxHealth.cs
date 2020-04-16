using Status;
using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/MaxHealth")]
    public class InteractableMaxHealth : Interactable
    {
        public int value;

        public override void Interact(Interactor interactor)
        {
            var holder = interactor.GetComponent<StatusEffectHolder>();
            holder.AddEffect(new MaxHealthBoostEffect(value));
        }
    }
}