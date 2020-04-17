using System;
using System.Collections.Generic;
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

        [SerializeField] protected float value;
        protected float? RuntimeValue;

        private readonly List<Action<FloatVariable>> _listeners = new List<Action<FloatVariable>>();

        protected void NotifyListeners()
        {
            foreach (var listener in _listeners)
            {
                listener.Invoke(this);
            }
        }

        public void AddListener(Action<FloatVariable> listener)
        {
            _listeners.Add(listener);
        }
    }
}