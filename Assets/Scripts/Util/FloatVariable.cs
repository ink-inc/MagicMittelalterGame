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

                return RuntimeValue.Value;
            }
            set
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (RuntimeValue == null || RuntimeValue != value)
                {
                    RuntimeValue = value;
                    NotifyListeners();
                }
            }
        }

        [Tooltip("Initial Value, only read once on load.")]
        public FloatConstant initialValue;

        protected float? RuntimeValue;

        public static FloatVariable Create(float initialValue, string attributeType = null)
        {
            FloatConstant floatConstant = FloatConstant.Create(initialValue);
            return Create(floatConstant, AttributeType.Create(attributeType));
        }

        public static FloatVariable Create(FloatConstant initialValue, AttributeType attributeType = null)
        {
            FloatVariable floatVariable = CreateInstance<FloatVariable>();
            floatVariable.initialValue = initialValue;
            floatVariable.attributeType = attributeType;
            return floatVariable;

        }
    }
}