using UnityEngine;
using Util;

[CreateAssetMenu(menuName = "Inventory/WeightSlowCalculation")]
public class WeightSlowCalculation : FloatCalculation
{
    [Tooltip("Current weight.")] public Float weight;

    [Tooltip("Maximum carryable weight. Set to negative value to disable maximum.")]
    public Float maxWeight;

    [Tooltip("Weight Percentage of minimum capacity at which the player starts receiving movement penalties. Disable movement penalties by setting this to 1.")]
    public Float weightSoftCap;

    [Tooltip("Maximum inflicted slowdown. Disable movement penalties by setting this to 0.")]
    public Float maxSlowdown;

    protected override void OnEnable()
    {
        base.OnEnable();
        weight.AddListener(OnDependencyChange);
        maxWeight.AddListener(OnDependencyChange);
        weightSoftCap.AddListener(OnDependencyChange);
        maxSlowdown.AddListener(OnDependencyChange);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        weight.RemoveListener(OnDependencyChange);
        maxWeight.RemoveListener(OnDependencyChange);
        weightSoftCap.RemoveListener(OnDependencyChange);
        maxSlowdown.RemoveListener(OnDependencyChange);
    }

    protected override float CalculateValue()
    {
        var relWeight = weight.Value / maxWeight.Value;

        if (maxWeight.Value <= 0
            || weightSoftCap.Value < 0 || weightSoftCap.Value >= 1
            || maxSlowdown.Value <= 0 || maxSlowdown.Value > 1
            || relWeight < weightSoftCap.Value)
        {
            return 0;
        }

        // quadratic curve which goes through {softCap, 0} and {1, -max} and is 0 for all capacity values in [0, softcap)
        var val = (relWeight - weightSoftCap.Value) / (1.0f - weightSoftCap.Value);
        return -maxSlowdown.Value * val * val;
    }
}