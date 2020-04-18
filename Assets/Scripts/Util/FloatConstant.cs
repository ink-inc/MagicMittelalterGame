using System;
using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "Float/Constant")]
    public class FloatConstant : Float
    {
        public override float Value
        {
            get => value;
            set => throw new InvalidOperationException("Cannot change Float Constant value!");
        }

        [SerializeField] protected float value;

        public static FloatConstant Create(float value)
        {
            var floatConstant = CreateInstance<FloatConstant>();
            floatConstant.value = value;
            return floatConstant;
        }
    }
}