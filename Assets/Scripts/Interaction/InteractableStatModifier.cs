using Stat;
using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/StatModifier")]
    public class InteractableStatModifier : Interactable
    {
        public StatModifier statModifier;

        public override void Interact(Interactor interactor)
        {
            var source = new StatModifierSource();
            var attributeHolders = interactor.GetComponents<AttributeHolder>();
            statModifier.ApplyModifier(source, attributeHolders);
        }

        private class StatModifierSource : IStatModifierSource
        {
        }
    }
}