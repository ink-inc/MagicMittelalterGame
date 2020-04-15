using Stat;

namespace Status
{
    public abstract class StatAttributeModifierEffect : StatusEffect, IStatModifierSource
    {
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