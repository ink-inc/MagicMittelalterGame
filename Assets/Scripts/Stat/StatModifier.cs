using System;
using UnityEngine;

namespace Stat
{
    [CreateAssetMenu(menuName = "Stat/Modifier")]
    public class StatModifier : ScriptableObject
    {
        public StatAttributeType attributeType;
        public StatModifierType modifierType;
        public float value;

        public float Apply(float baseValue, float currentValue)
        {
            switch (modifierType)
            {
                case StatModifierType.AdditiveAbsolute:
                    return value;
                case StatModifierType.AdditiveRelative:
                    return baseValue * value;
                case StatModifierType.MultiplicativeRelative:
                    return currentValue * value;
                default:
                    throw new InvalidOperationException("type not supported");
            }
        }

        public void ApplyModifier(IAttributeHolder holder, IStatModifierSource source)
        {
            holder.GetAttribute(attributeType).AddModifier(this, source);
        }

        public void RemoveModifier(IAttributeHolder holder, IStatModifierSource source)
        {
            holder.GetAttribute(attributeType).RemoveModifiers(this, source);
        }
    }
}