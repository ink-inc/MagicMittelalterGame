using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item/Equippable")]
public class InventoryItem_Equippable : InventoryItem
{
    public bool equipped = false;

    private void Reset()
    {
        consumable = false;
        useable = false;
        equippable = true;
        droppable = true;
        type = ItemCategory.Equippable;
    }

    public override void ContextAction()
    {
        Logger.log("Toggle Equip " + name);
        if (equipped)
        {
            Unequip();
            equipped = false;
            this.contextActionName = "Equip";
        }
        else
        {
            Equip();
            equipped = true;
            this.contextActionName = "Unequip";
        }
        InventoryDisplay inventoryDisplay = GameObject.FindObjectOfType<InventoryDisplay>();
        inventoryDisplay.Hide();
        inventoryDisplay.Show();
    }

    private void Equip()
    {
        Logger.log("Equipped");
    }

    private void Unequip()
    {
        Logger.log("Unequipped");
    }

    public bool IsEquipped()
    {
        return equipped;
    }
}