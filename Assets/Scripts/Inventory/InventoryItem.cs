using UnityEngine;

//TODO: Use categories instead of useable etc. bools
public enum ItemCategory { Consumable, Useable, Equippable, Other }

public abstract class InventoryItem : MonoBehaviour, IStatModifierSource
{
    public float weigth;
    internal StatModifier weightModifier;
    static AttributeType weightAttributeType;
    public Sprite icon;
    public Inventory inventory;

    public ItemCategory type;

    [Header("Display properties")]
    public new string name;

    public string subname;

    [TextArea]
    public string description;

    public string contextActionName;

    [Header("Context actions")]
    public bool consumable;

    public bool useable;
    public bool equippable;
    public bool droppable;

    public abstract void ContextAction();

    private void Start()
    {
        if (weightAttributeType == null)
        {
            weightAttributeType = AttributeType.Create("Weight");
        }
        weightModifier = ScriptableObject.CreateInstance<StatModifier>();
        weightModifier.value = FloatConstant.Create(weigth);
        weightModifier.modifierType = StatModifierType.AdditiveAbsolute;
        weightModifier.attributeType = weightAttributeType;
    }

    public virtual void Drop()
    {
        Logger.log("Drop " + name);
        Vector3 dropPosition = inventory.GetItemDropLocation().position;
        gameObject.SetActive(true);
        gameObject.transform.position = dropPosition;
        inventory.Remove(this);
    }

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetName()
    {
        return name;
    }

    public new string GetType()
    {
        return type.ToString();
    }

    public float GetWeight()
    {
        return weigth;
    }
}