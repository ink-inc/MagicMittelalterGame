using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Stat
{
    /// <summary>
    /// A StatAttribute is a managed floating point value with the possibility to add revertible and transparent StatModifiers.
    /// </summary>
    [CreateAssetMenu(menuName = "Stat/Attribute")]
    public class StatAttribute : FloatVariable
    {
        public StatAttributeType attributeType;

        /// <summary>
        /// The final value.
        /// </summary>
        public override float Value
        {
            get
            {
                if (RuntimeValue == null)
                {
                    RuntimeValue = CalculateValue();
                }

                return RuntimeValue.Value;
            }
        }

        private readonly SortedList<StatModifierType, List<StatModifierInstance>> _modifiers =
            new SortedList<StatModifierType, List<StatModifierInstance>>();

        /// <summary>
        /// Add a new StatModifier.
        /// </summary>
        /// <param name="modifier">new StatModifier</param>
        /// <param name="source"></param>
        public void AddModifier(StatModifier modifier, IStatModifierSource source)
        {
            if (!_modifiers.TryGetValue(modifier.modifierType, out var statModifiers))
            {
                statModifiers = new List<StatModifierInstance>();
                _modifiers.Add(modifier.modifierType, statModifiers);
            }

            var instance = new StatModifierInstance(modifier, this, source);
            statModifiers.Add(instance);
            MarkDirty();
        }

        /// <summary>
        /// Remove all StatModifierInstances of the given StatModifier from the given source.
        /// </summary>
        /// <param name="modifier">given StatModifier</param>
        /// <param name="source">given source</param>
        public void RemoveModifiers(StatModifier modifier, IStatModifierSource source)
        {
            if (_modifiers.TryGetValue(modifier.modifierType, out var statModifiers)
                && statModifiers.RemoveAll(instance => instance.Matches(modifier, source)) > 0)
            {
                MarkDirty();
            }
        }

        private float CalculateValue()
        {
            var currentValue = base.Value;

            foreach (var kvp in _modifiers)
            {
                var baseValue = currentValue;
                foreach (var modifier in kvp.Value)
                {
                    currentValue += modifier.Modifier.Apply(baseValue, currentValue);
                }
            }

            return currentValue;
        }

        /// <summary>
        /// Mark the cached value as outdated .
        /// </summary>
        public void MarkDirty()
        {
            RuntimeValue = null;
        }
    }
}