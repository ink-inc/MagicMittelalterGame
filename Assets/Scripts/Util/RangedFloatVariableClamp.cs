using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "Float/RangedVariableClamp")]
    public class RangedFloatVariableClamp : FloatVariable
    {
        public override float Value
        {
            get
            {
                Value = base.Value; // clamp value via 'set'
                return base.Value;
            }
            set => base.Value = Mathf.Clamp(value, min.Value, max.Value);
        }

        public FloatVariable min;
        public bool minInclusive;
        public FloatVariable max;
        public bool maxInclusive;

        private void OnEnable()
        {
            if (!CheckBounds() || !CheckMin() || !CheckMax())
            {
                Logger.logError("Error in FloatVariable: Value out of range!");
            }
        }

        private bool CheckBounds()
        {
            if (min == null || max == null)
            {
                return true;
            }

            return minInclusive && maxInclusive ? min.Value <= max.Value : min.Value < max.Value;
        }

        private bool CheckMin()
        {
            if (min == null)
            {
                return true;
            }

            return minInclusive ? Value >= min.Value : Value > min.Value;
        }

        private bool CheckMax()
        {
            if (max == null)
            {
                return true;
            }

            return maxInclusive ? Value <= max.Value : Value < max.Value;
        }
    }
}