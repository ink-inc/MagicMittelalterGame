using UnityEngine;

namespace Player {
    public class PlayerProperties : MonoBehaviour
    {
        public static PlayerProperties instance;
        public PlayerHealthbar playerHealthbar;

        [Header("Health Status")] public float health = 100f;

        public float maxHealth = 100f;

        [Header("Speed values")] public float walkingSpeed = 3f;

        public float runningSpeed = 6f;
        private float defaultWalkingSpeed = 3f;
        private float defaultRunningSpeed = 6f;

        public float sneakMultiplier = 0.7f;
        public float jumpPower = 450f;

        [Header("Inventory")] public float weight;

        [Tooltip("Maximum weight capacity of player in kg. Set to negative value for unlimited.")]
        public float weightCapacity = 50;

        [Tooltip(
            "Weight Percentage of maximum capacity at which the player will receive movement penalties (Default 75%). Set to negative vlaue for none")]
        public float softCap = 75;

        [Tooltip("Maximum slot capacity of player. Set to negative value for unlimited.")]
        public int slotCapacity = -1;

        private void Awake()
        {
            instance = this;
        }

        public float GetHealth()
        {
            return health;
        }

        public void SetHealth(float value)
        {
            health = value;
            playerHealthbar.Refresh();
        }

        public float GetMaxHealth()
        {
            return maxHealth;
        }

        public void SetMaxHealth(float value)
        {
            maxHealth = value;
        }

        public float Heal(float value)
        {
            SetHealth(GetHealth() + value);
            return GetHealth();
        }

        public float Damage(float value)
        {
            SetHealth(GetHealth() - value);
            return GetHealth();
        }

        public float GetWeightCapacity()
        {
            return weightCapacity;
        }

        public int GetSlotCapacity()
        {
            return slotCapacity;
        }

        public float GetWeight()
        {
            return weight;
        }

        public void SetWeight(float value)
        {
            weight = value;
        }

        public bool GetSlotCapacityEnabled()
        {
            return slotCapacity > 0;
        }

        public bool GetWeightCapacityEnabled()
        {
            return weightCapacity > 0;
        }

        public void CalculateSpeed()
        {
            float weightCapacityPercentage = weightCapacity / 100;
            float percentage = weight / weightCapacityPercentage;
            if (softCap > 0)
            {
                if (percentage < softCap)
                {
                    runningSpeed = defaultRunningSpeed;
                    walkingSpeed = defaultWalkingSpeed;
                }
                else
                {
                    //runningSpeed = defaultRunningSpeed - (defaultRunningSpeed * ((percentage-75)/25));        //linear regression
                    //walkingSpeed = defaultWalkingSpeed - (defaultWalkingSpeed * ((percentage - 75) / 25));
                    runningSpeed = defaultRunningSpeed -
                                   (defaultRunningSpeed *
                                    Mathf.Pow((((percentage - softCap) / (100 - softCap))), 2f)); //quadratic regression
                    walkingSpeed = defaultWalkingSpeed -
                                   (defaultWalkingSpeed * Mathf.Pow((((percentage - softCap) / (100 - softCap))), 2f));
                }
            }
        }

        public float GetSpeedPenaltyGradient()
        {
            /*float startPenaltyWeight;
            float endPenaltyWeight;*/
            float weightCapacityPercentage = weightCapacity / 100;
            float percentage = weight / weightCapacityPercentage;
            return ((percentage - softCap) / (100 - softCap)) * 100;
        }
    }
}