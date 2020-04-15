using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Status
{
    /// <summary>
    /// Unity Script which allows a GameObject to carry StatusEffects.
    /// </summary>
    public class StatusEffectHolder : MonoBehaviour
    {
        /// <summary>
        /// All StatusEffects.
        /// </summary>
        public ReadOnlyDictionary<string, StatusEffect>.ValueCollection Effects
        {
            get
            {
                if (_readonlyEffects == null)
                {
                    _readonlyEffects = new ReadOnlyDictionary<string, StatusEffect>(_effects);
                }

                return _readonlyEffects.Values;
            }
        }

        private readonly Dictionary<string, StatusEffect> _effects = new Dictionary<string, StatusEffect>();
        private ReadOnlyDictionary<string, StatusEffect> _readonlyEffects;

        /// <summary>
        /// Add a new StatusEffect.
        /// </summary>
        /// <param name="effect">new StatusEffect</param>
        /// <param name="active">optional active flag, per default a new StatusEffect is activated immediately</param>
        /// <returns>added or merged StatusEffect</returns>
        /// <exception cref="ArgumentException">on invalid StatusEffect</exception>
        public StatusEffect AddEffect(StatusEffect effect, bool active = true)
        {
            if (effect.Holder != null)
            {
                throw new ArgumentException("StatusEffect is already part of a StatusEffectHolder");
            }

            if (_effects.TryGetValue(effect.Id, out var existing))
            {
                // already exists, do stacking/merging logic
                existing.Merge(effect);
                return existing;
            }

            // new effect
            _effects.Add(effect.Id, effect);
            effect.Holder = this;
            effect.OnAdd();
            effect.Active = active;

            return effect;
        }

        /// <summary>
        /// Remove a StatusEffect by id.
        /// </summary>
        /// <param name="effectId">StatusEffect id</param>
        public void RemoveEffect(string effectId)
        {
            if (_effects.TryGetValue(effectId, out StatusEffect effect))
            {
                effect.MarkForRemoval();
            }
        }

        private void FixedUpdate()
        {
            var toRemove = new List<KeyValuePair<string, StatusEffect>>();

            foreach (var effectKvp in _effects)
            {
                // tick all valid status effects...
                if (!effectKvp.Value.MarkedForRemoval)
                {
                    effectKvp.Value.CheckActive();
                    if (effectKvp.Value.Active)
                    {
                        effectKvp.Value.Tick();
                    }
                }

                // and remove the rest
                if (effectKvp.Value.MarkedForRemoval)
                {
                    toRemove.Add(effectKvp);
                }
            }

            // removing here
            foreach (var effectKvp in toRemove)
            {
                effectKvp.Value.Active = false;
                effectKvp.Value.OnRemove();
                effectKvp.Value.Holder = null;
                _effects.Remove(effectKvp.Key);
            }
        }
    }
}