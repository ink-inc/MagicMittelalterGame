using System.Collections.Generic;
using Stat;
using Status;
using UnityEngine;
using Util;

[AddComponentMenu("Inventory/Inventory")]
public class Inventory : MonoBehaviour
{
    public PlayerProperties playerProperties;
    public InventoryDisplay inventoryDisplay;
    public Transform itemDropLocation;
    public StatusEffect weightEffect;

    private int slotsFilled;
    private List<InventoryItem> inventory;

    private void Start()
    {
        inventory = new List<InventoryItem>();
        GetComponent<StatusEffectHolder>().AddEffect(weightEffect, false);
    }

    public InventoryItem[] GetItems()
    {
        return inventory.ToArray();
    }

    public int GetSlotsUsed()
    {
        return inventory.Count;
    }

    public Transform GetItemDropLocation()
    {
        return itemDropLocation;
    }

    public bool Pickup(InventoryItem item)
    {
        if (CanPickup(item.weigth))
        {
            inventory.Add(item);
            item.inventory = this;
            
            var modifier = ScriptableObject.CreateInstance<StatModifier>();
            modifier.value = FloatConstant.Create(item.weigth);
            modifier.modifierType = StatModifierType.AdditiveAbsolute;
            playerProperties.weight.AddModifier(modifier, item);
            
            RefreshInventory();
            return true;
        }
        return false;
    }

    public void Remove(InventoryItem item, bool destroy = false)
    {
        inventory.Remove(item);
        playerProperties.weight.RemoveModifiers(item);
        RefreshInventory();
        if (destroy)
        {
            Destroy(item.gameObject);
        }
    }

    private void RefreshInventory()
    {
        slotsFilled = inventory.Count;
        inventoryDisplay.CloseContextMenu();
        if (inventoryDisplay.active)
        {
            inventoryDisplay.Hide();
            inventoryDisplay.Show();
        }
    }

    public bool CanPickup(float itemWeight)
    {
        //TODO: This is ugly... but it should work
        float weight = playerProperties.weight.Value;
        return (!playerProperties.GetWeightCapacityEnabled() || weight + itemWeight <= playerProperties.maxWeight.Value) && (!playerProperties.GetSlotCapacityEnabled() || slotsFilled <= playerProperties.slotCapacity);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryDisplay.Toggle();
        }
    }
}