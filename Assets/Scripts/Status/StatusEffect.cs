using System;
using Stat;
using UnityEngine;

namespace Status
{
    /// <summary>
    /// A StatusEffect is temporary or permanent toggleable (de)buff that may either do something each tick or change StatAttributes while active.
    /// Can be applied to StatusEffectHolders.
    /// </summary>
    public abstract class StatusEffect
    {
        /// <summary>
        /// Unique id.
        /// </summary>
        public abstract string Id { get; }

        /// <summary>
        /// Holder of this StatusEffect.
        /// </summary>
        public StatusEffectHolder Holder { get; set; }

        /// <summary>
        /// Flag if thei StatusEffect should be removed by the next tick.
        /// </summary>
        public bool MarkedForRemoval { get; private set; }

        /// <summary>
        /// Flag if this StatusEffect is active right now.
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
                        OnEnable();
                    }
                    else
                    {
                        OnDisable();
                    }
                }
            }
        }

        /// <summary>
        /// Time in ticks this StatusEffect has been active.
        /// </summary>
        public int TimeActive { get; private set; }

        /// <summary>
        /// Duration property, may be 0 when permanent.
        /// But it is impossible to set it to 0 from the outside.
        /// </summary>
        public int Duration
        {
            get => _duration;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("duration must be positive");
                }

                _duration = value;
            }
        }

        /// <summary>
        /// Temporary StatusEffect flag
        /// </summary>
        public readonly bool Timed;

        private bool _active;
        private int _duration;

        /// <summary>
        /// Create a new temporary or permanent StatusEffect.
        /// </summary>
        /// <param name="duration">duration in FixedUpdate ticks, may be 0 which makes this StatusEffect permanent</param>
        /// <exception cref="ArgumentException">on invalid duration</exception>
        protected StatusEffect(int duration = 0)
        {
            if (duration < 0)
            {
                throw new ArgumentException("duration must not be negative");
            }

            if (duration == 0)
            {
                Timed = false;
            }
            else
            {
                Duration = duration;
                Timed = true;
            }
        }

        /// <summary>
        /// Event Handler for adding to a StatusEffectHolder. Gets called after Holder is available.
        /// </summary>
        public virtual void OnAdd()
        {
        }

        /// <summary>
        /// Event Handler for removing from a StatusEffectHolder. Gets called before Holder becomes unavailable.
        /// </summary>
        public virtual void OnRemove()
        {
        }

        /// <summary>
        /// Event Handler for becoming active.
        /// </summary>
        public virtual void OnEnable()
        {
        }

        /// <summary>
        /// Event Handler for becoming inactive.
        /// </summary>
        public virtual void OnDisable()
        {
            foreach (var attributeHolder in Holder.GetComponents<IAttributeHolder>())
            {
                attributeHolder.RemoveAllModifiersFrom(this);
            }
        }

        /// <summary>
        /// Updates this StatusEffect's Active status.
        /// </summary>
        public virtual void CheckActive()
        {
        }

        /// <summary>
        /// Event Handler for update logic. Gets called every FixedUpdate.
        /// </summary>
        public virtual void Tick()
        {
            TimeActive++;

            if (Timed && TimeActive >= Duration)
            {
                MarkForRemoval();
            }
        }

        /// <summary>
        /// Merge with a new effect with the same id.
        /// </summary>
        /// <param name="newEffect">new effect</param>
        /// <exception cref="ArgumentException">when the types do not match</exception>
        public virtual void Merge(StatusEffect newEffect)
        {
            if (Timed != newEffect.Timed)
            {
                throw new ArgumentException("cannot merge a timed effect with a permanent effect");
            }

            if (Timed) // for timed effects...
            {
                // the new time is added to the current time
                Duration += newEffect.Duration;
            }
        }

        /// <summary>
        /// Mark this StatusEffect for removal by the next update tick.
        /// </summary>
        public void MarkForRemoval()
        {
            MarkedForRemoval = true;
        }
    }
}