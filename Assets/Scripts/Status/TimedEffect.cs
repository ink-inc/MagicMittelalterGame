using System;

namespace Status
{
    public abstract class TimedEffect : StatusEffect
    {
        /// <summary>
        /// Duration property.
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

                if (TimeActive >= Duration)
                {
                    MarkForRemoval();
                }
            }
        }

        private int _duration;

        protected TimedEffect(int duration)
        {
            Duration = duration;
        }

        public override void Tick()
        {
            base.Tick();

            if (TimeActive >= Duration)
            {
                MarkForRemoval();
            }
        }

        public override void Merge(StatusEffect newEffect)
        {
            if (newEffect is TimedEffect timed)
            {
                base.Merge(timed);
                Duration += timed.Duration;
            }
            else
            {
                throw new ArgumentException("type mismatch");
            }
        }
    }
}