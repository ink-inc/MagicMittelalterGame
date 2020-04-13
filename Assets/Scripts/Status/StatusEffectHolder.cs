using System;
using System.Collections.Generic;
using UnityEngine;

namespace Status
{
    public class StatusEffectHolder : MonoBehaviour
    {
        private readonly Dictionary<string, StatusEffect> _activeEffects = new Dictionary<string, StatusEffect>();

        public void AddEffect(StatusEffect effect)
        {
            if (effect.Holder != null)
            {
                throw new ArgumentException("StatusEffect is already part of a StatusEffectHolder");
            }

            if (_activeEffects.TryGetValue(effect.Id, out var existing))
            {
                // already exists, do stacking/merging logic
                existing.Merge(effect);
            }
            else
            {
                // new effect
                _activeEffects.Add(effect.Id, effect);
                effect.Holder = this;
                effect.OnAdd();
            }
        }

        public void RemoveEffect(string effectId)
        {
            if (_activeEffects.TryGetValue(effectId, out StatusEffect effect))
            {
                effect.MarkForRemoval();
            }
        }

        private void FixedUpdate()
        {
            var toRemove = new List<KeyValuePair<string, StatusEffect>>();

            foreach (var effectKvp in _activeEffects)
            {
                // tick all valid status effects...
                if (!effectKvp.Value.MarkedForRemoval)
                {
                    effectKvp.Value.Tick();
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
                effectKvp.Value.OnRemove();
                effectKvp.Value.Holder = null;
                _activeEffects.Remove(effectKvp.Key);
            }
        }
    }
}