using UnityEngine;

namespace Util
{
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

        [Tooltip("Only read once, watch out!")]
        public Float initialValue;
        
        protected float? RuntimeValue;
    }
}