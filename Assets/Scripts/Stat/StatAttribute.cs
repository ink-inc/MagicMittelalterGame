using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Util;

namespace Stat
{
    /// <summary>
    /// A StatAttribute is a managed floating point value with the possibility to add revertible and transparent StatModifiers.
    /// </summary>
    [CreateAssetMenu(menuName = "Stat/Attribute")]
    public class StatAttribute : FloatCalculation
    {
        /// <summary>
        /// Base value.
        /// </summary>
        [Tooltip("Base value")] public Float baseValue;

        private readonly SortedList<StatModifierType, List<StatModifierInstance>> _modifiers =
            new SortedList<StatModifierType, List<StatModifierInstance>>();

        public static StatAttribute Create(float baseValue)
        {
            return Create(FloatConstant.Create(baseValue));
        }

        public static StatAttribute Create(Float baseValue, Float min = null, Float max = null,
            AttributeType attributeType = null)
        {
            StatAttribute statAttribute = CreateInstance<StatAttribute>();
            statAttribute.baseValue = baseValue;
            statAttribute.min = min;
            statAttribute.max = max;
            statAttribute.attributeType = attributeType;
            return statAttribute;
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            baseValue.AddListener(OnDependencyChange);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            baseValue.RemoveListener(OnDependencyChange);
        }

        /// <summary>
        /// Add a new StatModifier.
        /// </summary>
        /// <param name="modifier">new StatModifier</param>
        /// <param name="source">modifier source</param>
        /// <returns>true if changed</returns>
        public bool AddModifier(StatModifier modifier, IStatModifierSource source)
        {
            if (modifier.attributeType.Type != attributeType.Type)
            {
                return false;
            }

            if (!_modifiers.TryGetValue(modifier.modifierType, out var statModifiers))
            {
                statModifiers = new List<StatModifierInstance>();
                _modifiers.Add(modifier.modifierType, statModifiers);
            }

            var instance = new StatModifierInstance(modifier, this, source);
            statModifiers.Add(instance);
            modifier.value.AddListener(OnDependencyChange);
            MarkDirty();

            return true;
        }

        /// <summary>
        /// Remove all StatModifierInstances from the given source.
        /// </summary>
        /// <param name="source">given source</param>
        /// <returns>true if changed</returns>
        public bool RemoveModifiers(IStatModifierSource source)
        {
            var removed = 0;
            foreach (var statModifierInstances in _modifiers.Values)
            {
                for (var i = statModifierInstances.Count - 1; i >= 0; i--)
                {
                    var instance = statModifierInstances[i];
                    if (instance.Matches(source))
                    {
                        instance.Modifier.value.RemoveListener(OnDependencyChange);
                        statModifierInstances.RemoveAt(i);
                        removed++;
                    }
                }
            }

            if (removed > 0)
            {
                MarkDirty();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove all StatModifierInstances of the given StatModifier from the given source.
        /// </summary>
        /// <param name="modifier">given StatModifier</param>
        /// <param name="source">given source</param>
        /// <returns>true if changed</returns>
        public bool RemoveModifier(StatModifier modifier, IStatModifierSource source)
        {
            if (modifier.attributeType.Type != attributeType.Type)
            {
                return false;
            }

            if (_modifiers.TryGetValue(modifier.modifierType, out var statModifierInstances))
            {
                var removed = 0;
                for (var i = statModifierInstances.Count - 1; i >= 0; i--)
                {
                    var instance = statModifierInstances[i];
                    if (instance.Matches(modifier, source))
                    {
                        instance.Modifier.value.RemoveListener(OnDependencyChange);
                        statModifierInstances.RemoveAt(i);
                        removed++;
                    }
                }

                if (removed > 0)
                {
                    MarkDirty();
                    return true;
                }
            }

            return false;
        }

        protected override float CalculateValue()
        {
            var currentValue = baseValue.Value;

            foreach (var kvp in _modifiers)
            {
                var baseValueType = currentValue;
                foreach (var modifier in kvp.Value)
                {
                    currentValue += modifier.Modifier.GetModification(baseValueType, currentValue);
                }
            }

            return currentValue;
        }

        public override string ToString()
        {
            var s = base.ToString();

            var modifiers = string.Join(" | ", _modifiers.SelectMany(kvp => kvp.Value));
            if (modifiers.Length > 0)
            {
                s += $" <{modifiers}>";
            }

            return s;
        }
    }
}