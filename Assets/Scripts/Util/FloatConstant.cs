using System;
using UnityEngine;

namespace Util
{
    /// <summary>
    /// An implementation of Float with a constant value.
    /// </summary>
    [CreateAssetMenu(menuName = "Float/Constant")]
    public class FloatConstant : Float
    {
        public override float Value
        {
            get => value;
            set => throw new InvalidOperationException("Cannot change Float Constant value!");
        }

        [Tooltip("Constant Value")] [SerializeField] protected float value;

        /// <summary>
        /// Static factory method.
        /// </summary>
        /// <param name="value">float value to wrap</param>
        /// <returns>new FloatConstant</returns>
        public static FloatConstant Create(float value)
        {
            var floatConstant = CreateInstance<FloatConstant>();
            floatConstant.value = value;
            return floatConstant;
        }
    }
}