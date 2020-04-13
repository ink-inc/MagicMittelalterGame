using System;

namespace Status
{
    public abstract class StatusEffect
    {
        public abstract string Id { get; }

        public StatusEffectHolder Holder { get; set; }

        public bool MarkedForRemoval { get; private set; }

        public int TimeActive { get; private set; }

        public float Strength
        {
            get => _strength;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("strength must be positive");
                }

                _strength = value;
            }
        }

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

        public readonly bool Timed;
        private float _strength;
        private int _duration;

        protected StatusEffect(float strength = 1.0f, int duration = 0)
        {
            if (duration < 0)
            {
                throw new ArgumentException("duration must not be negative");
            }

            Strength = strength;

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

        public virtual void OnAdd()
        {
        }

        public virtual void OnRemove()
        {
        }

        public virtual void Tick()
        {
            TimeActive++;

            if (Timed && TimeActive >= Duration)
            {
                MarkForRemoval();
            }
        }

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

                // and the strength is set to the bigger strength value
                Strength = Math.Max(Strength, newEffect.Strength);
            }
            else // and for permanent effects...
            {
                // the new strength is added to the current strength
                Strength += newEffect.Strength;
            }
        }

        public void MarkForRemoval()
        {
            MarkedForRemoval = true;
        }
    }
}