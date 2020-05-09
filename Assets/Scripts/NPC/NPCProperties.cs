using Stat;
using Util;

namespace NPC
{
    public class NpcProperties : CharacterProperties
    {
        private void Start()
        {
            health = FloatVariable.Create(10f, "Health");
            maxHealth = StatAttribute.Create(10f, attributeType: "MaxHealth");
            
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