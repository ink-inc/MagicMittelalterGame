using Stat;
using Util;

namespace Character.NPC
{
    public class NpcProperties : CharacterProperties
    {
        protected override void Start()
        {
            base.Start();
            team = FloatVariable.Create(1f, "Team");

            maxHealth = StatAttribute.Create(10f, "MaxHealth");
            health = FloatVariable.Create(FloatConstant.Create(maxHealth.Value), FloatConstant.Create(0), maxHealth,
                AttributeType.Create("Health"));

            armor = StatAttribute.Create(10f, "Armor");

            speed = StatAttribute.Create(3f, "Speed");
            sneakMultiplier = 0.7f;
            runMultiplier = 2f;

            jumpPower = 450f;

            weight = StatAttribute.Create(0, "Weight");
            maxWeight = StatAttribute.Create(0, "MaxWeight");

            slotCapacity = -1;
        }
    }
}