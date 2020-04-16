using Status;
using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/Poison")]
    public class InteractablePoison : Interactable
    {
        public float strength;
        public int duration;

        public override void Interact(Interactor interactor)
        {
            var holder = interactor.GetComponent<StatusEffectHolder>();
            holder.AddEffect(new PoisonEffect(strength, duration));
        }
    }
}