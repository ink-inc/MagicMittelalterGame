namespace Status
{
    public class PoisonEffect : StatusEffect
    {
        public override string Id => "poison";

        public PoisonEffect(float strength = 1.0f, int duration = 0) : base(strength, duration)
        {
        }

        public override void Tick()
        {
            if (Holder.TryGetComponent<PlayerProperties>(out var playerProperties))
            {
                playerProperties.Damage(Strength);
            }

            base.Tick();
        }
    }
}