using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item/Consumable")]
public class InventoryItem_Consumable : InventoryItem
{
    [Header("Restore Health")]
    public bool effect_restoreHealth;

    public float healthAmount;
    //Possible refactor: Effect-upper class -> Can be attached to anything that uses an effect, potions etc.

    private void Reset()
    {
        consumable = true;
        useable = false;
        equippable = false;
        droppable = true;
        type = ItemCategory.Consumable;
    }

    public override void ContextAction()
    {
        Logger.log("Consume " + name);
        if (effect_restoreHealth)
        {
            PlayerProperties.instance.Heal(healthAmount);
        }
        inventory.Remove(this, true);
    }
}