using System;
using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "Float/Constant")]
    public class FloatConstant : FloatVariable
    {
        public override float Value
        {
            get => value;
            set => throw new InvalidOperationException("Cannot change Float Constant value!");
        }
    }
}