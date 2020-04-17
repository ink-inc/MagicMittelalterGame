using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "Float/Variable")]
    public class FloatVariable : ScriptableObject
    {
        public virtual float Value
        {
            get
            {
                if (RuntimeValue == null)
                {
                    RuntimeValue = value;
                }

                return RuntimeValue.Value;
            }
            set => RuntimeValue = value;
        }

        [SerializeField] protected float value;
        protected float? RuntimeValue;
    }
}