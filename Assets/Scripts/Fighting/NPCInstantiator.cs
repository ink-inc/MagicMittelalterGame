using Stat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class NPCInstantiator : MonoBehaviour
{
    [Header("Health")]
    public AttributeType attributeType;
    public FloatConstant initialValue;
    public FloatConstant minH;
    public StatAttribute maxH;

    [Header("MaxHealth")]
    public AttributeType attributeTypeMx;
    public FloatConstant minMx;
    public Float maxMx;
    public FloatConstant baseValue;

    private RangedFloatVariableClamp _health;
    private StatAttribute _maxHealth;

    private PlayerProperties _properties;
    private NPCHealthbar _healthbar;

    void Start()
    {
        // instantiate
        _health = ScriptableObject.CreateInstance<RangedFloatVariableClamp>();
        _health.Init(attributeType, initialValue, minH, maxH);
        _maxHealth = ScriptableObject.CreateInstance<StatAttribute>();
        _maxHealth.Init(attributeTypeMx, minMx, maxMx, baseValue);

        // get components
        _properties = gameObject.GetComponent<PlayerProperties>();
        _healthbar = gameObject.GetComponentInChildren<NPCHealthbar>();

        // references
        _properties.health = _health;
        _properties.maxHealth = _maxHealth;
        _healthbar.health = _health;
        _healthbar.maxHealth = _maxHealth;

        _healthbar.OnEnable();
    }
}
