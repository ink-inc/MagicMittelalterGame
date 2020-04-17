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
            var instance = new StatusEffectInstance(effect, this);

            _effects.Add(instance);
            instance.OnAdd();
            instance.Active = active;

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
    }
}