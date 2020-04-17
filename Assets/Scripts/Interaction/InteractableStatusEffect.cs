using Status;
using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/StatusEffect")]
    public class InteractableStatusEffect : Interactable
    {
        public StatusEffect effect;

        public override void Interact(Interactor interactor)
        {
            var holder = interactor.GetComponent<StatusEffectHolder>();
            holder.AddEffect(effect);
        }
    }
}