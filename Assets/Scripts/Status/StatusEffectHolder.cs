﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HUD;
using UnityEngine;

namespace Status
{
    /// <summary>
    /// Unity Script which allows a GameObject to carry StatusEffectInstances.
    /// </summary>
    public class StatusEffectHolder : MonoBehaviour
    {
        public StatusEffectHUD effectHUD;

        /// <summary>
        /// All StatusEffectInstances.
        /// </summary>
        public ReadOnlyCollection<StatusEffectInstance> Effects =>
            _readonlyEffects ?? (_readonlyEffects = new ReadOnlyCollection<StatusEffectInstance>(_effects));

        private readonly List<StatusEffectInstance> _effects = new List<StatusEffectInstance>();
        private ReadOnlyCollection<StatusEffectInstance> _readonlyEffects;

        /// <summary>
        /// Add a new StatusEffect to this StatusEffectHolder.
        /// </summary>
        /// <param name="effect">new StatusEffect</param>
        /// <param name="active">optional active flag, per default a new StatusEffect is activated immediately</param>
        /// <returns>added StatusEffectInstance</returns>
        public StatusEffectInstance AddEffect(StatusEffect effect, bool active = true)
        {
            if (effect == null)
            {
                throw new ArgumentException("effect must not be null.");
            }

            var instance = new StatusEffectInstance(effect, this);

            _effects.Add(instance);
            instance.OnAdd();
            instance.Active = active;

            if (effectHUD != null && effect.showInHUD)
            {
                effectHUD.AddEffect(instance);
            }

            return instance;
        }

        private void FixedUpdate()
        {
            for (var i = _effects.Count - 1; i >= 0; i--)
            {
                var instance = _effects[i];

                // tick all status effects...
                instance.Tick();

                // and remove the marked ones
                if (instance.MarkedForRemoval)
                {
                    instance.Active = false;
                    instance.OnRemove();
                    _effects.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Get all active StatusEffectInstances.
        /// </summary>
        /// <returns>active StatusEffectInstances</returns>
        public List<StatusEffectInstance> GetActiveEffects()
        {
            return Effects.Where(effect => effect.Active).ToList();
        }
    }
}