namespace Status
{
    /// <summary>
    /// Base class for a temporary effect.
    /// </summary>
    public abstract class TimedEffect : StatusEffect
    {
        /// <summary>
        /// Duration in ticks.
        /// </summary>
        public int duration;

        public override void Tick(StatusEffectInstance instance)
        {
            base.Tick(instance);

            if (instance.TimeActive >= duration)
            {
                instance.MarkForRemoval();
            }
        }
    }
}