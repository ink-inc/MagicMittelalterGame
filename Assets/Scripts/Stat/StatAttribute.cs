using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stat
{
    /// <summary>
    /// A StatAttribute is a managed floating point value with the possibility to add revertible and transparent StatModifiers.
    /// </summary>
    public class StatAttribute
    {
        /// <summary>
        /// Base value.
        /// </summary>
        public float BaseValue
        {
            get => _baseValue;
            set
            {
                if (!Mathf.Approximately(_baseValue, value))
                {
                    _baseValue = value;
                    MarkDirty();
                }
            }
        }

        /// <summary>
        /// The final value.
        /// </summary>
        public float Value
        {
            get
            {
                if (_cachedValue == null)
                {
                    float value = BaseValue;

                    foreach (var kvp in _modifiers)
                    {
                        float @base = value;
                        foreach (var modifier in kvp.Value)
                        {
                            value = modifier.Apply(@base, value);
                        }
                    }

                    _cachedValue = value;
                }

                // ReSharper disable once PossibleInvalidOperationException
                return _cachedValue.Value;
            }
        }

        private float _baseValue;
        private readonly SortedList<StatModifierType, List<StatModifier>> _modifiers;
        private readonly List<Action<StatAttribute>> _listeners;
        private float? _cachedValue;

        /// <summary>
        /// Create a new StatAttribute with the given base value.
        /// </summary>
        /// <param name="baseValue">base value</param>
        public StatAttribute(float baseValue)
        {
            BaseValue = baseValue;
            _modifiers = new SortedList<StatModifierType, List<StatModifier>>();
            _listeners = new List<Action<StatAttribute>>();
        }

        /// <summary>
        /// Get all StatModifiers which come from a given source.
        /// </summary>
        /// <param name="source">given source</param>
        /// <returns>found StatModifiers</returns>
        public List<StatModifier> GetModifiersFrom(object source)
        {
            var list = new List<StatModifier>();

            foreach (var kvp in _modifiers)
            {
                foreach (var statModifier in kvp.Value)
                {
                    if (statModifier.Source == source)
                    {
                        list.Add(statModifier);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Add a new StatModifier.
        /// </summary>
        /// <param name="modifier">new StatModifier</param>
        public void AddModifier(StatModifier modifier)
        {
            if (!_modifiers.TryGetValue(modifier.Type, out var statModifiers))
            {
                statModifiers = new List<StatModifier>();
                _modifiers.Add(modifier.Type, statModifiers);
            }

            statModifiers.Add(modifier);
            modifier.Owner = this;
            MarkDirty();
        }

        /// <summary>
        /// Remove a given StatModifier.
        /// </summary>
        /// <param name="modifier">StatModifier to remove</param>
        public void RemoveModifier(StatModifier modifier)
        {
            if (_modifiers.TryGetValue(modifier.Type, out var statModifiers))
            {
                modifier.Owner = null;
                statModifiers.Remove(modifier);
                MarkDirty();
            }
        }

        /// <summary>
        /// Remove all StatModifiers which come from the given source.
        /// </summary>
        /// <param name="source">given source</param>
        public void RemoveModifiersFrom(object source)
        {
            foreach (var kvp in _modifiers)
            {
                for (var i = kvp.Value.Count - 1; i >= 0; i--)
                {
                    var statModifier = kvp.Value[i];
                    if (statModifier.Source == source)
                    {
                        statModifier.Owner = null;
                        kvp.Value.RemoveAt(i);
                        MarkDirty();
                    }
                }
            }
        }

        /// <summary>
        /// Mark the cached value as outdated and notify all listeners.
        /// </summary>
        public void MarkDirty()
        {
            _cachedValue = null;
            if (_listeners != null) // check if this object is fully instantiated
            {
                foreach (var listener in _listeners)
                {
                    listener.Invoke(this);
                }
            }
        }

        /// <summary>
        /// Add a listener method which will be invoked every time the final value changes.
        /// </summary>
        /// <param name="action">listener</param>
        /// <returns>this for chaining</returns>
        public StatAttribute AddListener(Action<StatAttribute> action)
        {
            _listeners.Add(action);
            return this;
        }
    }
}