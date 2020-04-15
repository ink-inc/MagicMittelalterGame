using Stat;

namespace Status
{
    public abstract class TimedStatAttributeModifierEffect : TimedEffect
    {
        protected TimedStatAttributeModifierEffect(int duration) : base(duration)
        {
        }

        public abstract void ApplyModifiers();

        public override void OnEnable()
        {
            base.OnEnable();
            ApplyModifiers();
        }

        public override void OnDisable()
        {
            base.OnDisable();
            foreach (var attributeHolder in Holder.GetComponents<IAttributeHolder>())
            {
                attributeHolder.RemoveAllModifiersFrom(this);
            }
        }
    }
}