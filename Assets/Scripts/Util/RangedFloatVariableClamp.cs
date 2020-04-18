using System;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// An extension of float variable which clamps the runtime value on change.
    /// </summary>
    [CreateAssetMenu(menuName = "Float/RangedVariableClamp")]
    public class RangedFloatVariableClamp : FloatVariable
    {
        public override float Value
        {
            get
            {
                base.Value = Clamp(base.Value);
                return base.Value;
            }
            set => base.Value = Clamp(value);
        }

        public Float min;
        public Float max;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (!CheckBounds())
            {
                throw new ArgumentException("Error in FloatVariable: Bounds are invalid!");
            }

            if (!CheckMin() || !CheckMax())
            {
                throw new ArgumentException("Error in FloatVariable: Value out of range!");
            }
        }

        private bool CheckBounds()
        {
            if (min == null || max == null)
            {
                return true;
            }

            return min.Value <= max.Value;
        }

        private bool CheckMin()
        {
            if (min == null)
            {
                return true;
            }

            return Value >= min.Value;
        }

        private bool CheckMax()
        {
            if (max == null)
            {
                return true;
            }

            return Value <= max.Value;
        }

        protected float Clamp(float val)
        {
            if (!CheckBounds())
            {
                throw new InvalidOperationException("Error in FloatVariable: Bounds are invalid!");
            }

            if (min != null)
            {
                val = Mathf.Max(min.Value, val);
            }

            if (max != null)
            {
                val = Mathf.Min(max.Value, val);
            }

            return val;
        }
    }
}