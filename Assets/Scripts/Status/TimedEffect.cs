using UnityEngine;

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

        public int GetTimeRemaining(StatusEffectInstance instance)
        {
            return duration - instance.TimeActive;
        }

        public float GetTimeRemainingSeconds(StatusEffectInstance instance)
        {
            return Time.fixedDeltaTime * GetTimeRemaining(instance);
        }

        public override string GetHUDText(StatusEffectInstance instance)
        {
            return $"{GetTimeRemainingSeconds(instance):F1} s";
        }

        public override string ToString(StatusEffectInstance instance)
        {
            return base.ToString(instance) + $": {GetTimeRemainingSeconds(instance):0.##} s";
        }
    }
}