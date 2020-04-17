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

        public bool ApplyModifier(IStatModifierSource source, params IAttributeHolder[] holders)
        {
            foreach (var holder in holders)
            {
                var attribute = holder.GetAttribute(attributeType);
                if (attribute != null && attribute.AddModifier(this, source))
                {
                    return true;
                }
            }

            return false;
        }

        public bool RemoveModifier(IStatModifierSource source, params IAttributeHolder[] holders)
        {
            foreach (var holder in holders)
            {
                var attribute = holder.GetAttribute(attributeType);
                if (attribute != null && attribute.RemoveModifier(this, source))
                {
                    return true;
                }
            }

            return false;
        }
    }
}