using System.Collections.Generic;
using Stat;
using UnityEngine;

namespace Status
{
    [CreateAssetMenu(menuName = "StatusEffect/StatAttributeModifier")]
    public class StatAttributeModifierEffect : StatusEffect
    {
        public List<StatModifier> modifiers;

        public override void OnActive(StatusEffectInstance instance)
        {
            base.OnActive(instance);

            var attributeHolder = instance.Holder.GetComponent<IAttributeHolder>();
            foreach (var statModifier in modifiers)
            {
                statModifier.ApplyModifier(attributeHolder, instance);
            }
        }

        public override void OnInactive(StatusEffectInstance instance)
        {
            base.OnInactive(instance);

            var attributeHolder = instance.Holder.GetComponent<IAttributeHolder>();
            foreach (var statModifier in modifiers)
            {
                statModifier.RemoveModifier(attributeHolder, instance);
            }
        }
    }
}