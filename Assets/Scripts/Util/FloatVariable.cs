using System;
using Stat;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// An implementation of Float with an initial value that may be changed during runtime.
    /// </summary>
    [CreateAssetMenu(menuName = "Float/Variable")]
    public class FloatVariable : Float
    {
        public override float Value
        {
            get
            {
                if (RuntimeValue == null)
                {
                    RuntimeValue = initialValue.Value;
                }

                Value = RuntimeValue.Value; // clamp value in set

                return RuntimeValue.Value;
            }
            set
            {
                var clamped = Clamp(value);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (RuntimeValue == null || RuntimeValue != clamped)
                {
                    var oldValue = RuntimeValue.GetValueOrDefault(0);
                    RuntimeValue = clamped;
                    NotifyListeners(oldValue);
                }
            }
        }

        [Tooltip("Initial Value, only read once on load.")]
        public FloatConstant initialValue;

        public Float min;
        public Float max;

        protected float? RuntimeValue;

        public static FloatVariable Create(float initialValue, string attributeType = null)
        {
            FloatConstant floatConstant = FloatConstant.Create(initialValue);
            AttributeType type = attributeType == null ? null : AttributeType.Create(attributeType);
            return Create(floatConstant, attributeType: type);
        }

        public static FloatVariable Create(FloatConstant initialValue, Float min = null, Float max = null,
            AttributeType attributeType = null)
        {
            FloatVariable floatVariable = CreateInstance<FloatVariable>();
            floatVariable.initialValue = initialValue;
            floatVariable.min = min;
            floatVariable.max = max;
            floatVariable.attributeType = attributeType;
            return floatVariable;
        }

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