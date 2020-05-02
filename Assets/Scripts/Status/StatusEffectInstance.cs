using Stat;
using UnityEngine;

namespace Status
{
    /// <summary>
    /// Represents an applied instance of a StatusEffect.
    /// </summary>
    public class StatusEffectInstance : IStatModifierSource
    {
        /// <summary>
        /// Actual StatusEffect.
        /// </summary>
        public StatusEffect Effect { get; }

        /// <summary>
        /// Holder of this StatusEffectInstance.
        /// </summary>
        public StatusEffectHolder Holder { get; }

        /// <summary>
        /// Flag if the StatusEffectInstance should be removed by the next tick.
        /// </summary>
        public bool MarkedForRemoval { get; private set; }

        /// <summary>
        /// Flag if this StatusEffectInstance is active right now.
        /// </summary>
        public bool Active
        {
            get => _active;
            set
            {
                if (value != _active)
                {
                    _active = value;
                    if (_active)
                    {
                        OnActive();
                    }
                    else
                    {
                        OnInactive();
                    }
                }
            }
        }

        private bool _active;

        /// <summary>
        /// Time in ticks this StatusEffect has been active.
        /// </summary>
        public int TimeActive { get; private set; }

        public StatusEffectInstance(StatusEffect effect, StatusEffectHolder holder)
        {
            Effect = effect;
            Holder = holder;
        }

        public void MarkForRemoval()
        {
            MarkedForRemoval = true;
        }

        public void OnAdd()
        {
            Effect.OnAdd(this);
        }

        public void OnRemove()
        {
            Effect.OnRemove(this);
        }

        public void OnActive()
        {
            Effect.OnActive(this);
        }

        public void OnInactive()
        {
            Effect.OnInactive(this);
        }

        public void Tick()
        {
            if (!MarkedForRemoval)
            {
                Effect.CheckActive(this);
                if (Active)
                {
                    Effect.Tick(this);
                    TimeActive++;
                }
            }
        }

        public string GetName()
        {
            return Effect.name;
        }

        public string GetHUDText()
        {
            return Effect.GetHUDText(this);
        }

        public override string ToString()
        {
            return $"{Effect.ToString(this)}";
        }
    }
}