using Stat;
using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/StatModifier")]
    public class InteractableStatModifier : Interactable, IStatModifierSource
    {
        public StatModifier statModifier;

        public override void Interact(Interactor interactor)
        {
            var attributeHolders = interactor.GetComponents<AttributeHolder>();
            statModifier.ApplyModifier(this, attributeHolders);
        }

        public string GetName()
        {
            return gameObject.name;
        }
    }
}