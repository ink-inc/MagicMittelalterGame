using System;
using UnityEngine;

namespace Util
{
    public abstract class FloatCalculation : Float
    {
        public override float Value
        {
            get
            {
                if (!CachedValue.HasValue)
                {
                    CachedValue = Clamp(CalculateValue());
                }

                return CachedValue.Value;
            }
            set => throw new InvalidOperationException("Cannot change FloatCalculation value!");
        }

        protected float? CachedValue;

        public Float min;
        public Float max;

        protected override void OnEnable()
        {
            if (!CheckBounds())
            {
                throw new ArgumentException("Error in FloatCalculation: Bounds are invalid!");
            }

            if (!CheckMin() || !CheckMax())
            {
                throw new ArgumentException("Error in FloatCalculation: Value out of range!");
            }
        }

        protected abstract float CalculateValue();

        public void MarkDirty()
        {
            CachedValue = null;
            NotifyListeners();
        }

        public void MarkDirty(Float f)
        {
            MarkDirty();
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
                throw new InvalidOperationException("Error in FloatCalculation: Bounds are invalid!");
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