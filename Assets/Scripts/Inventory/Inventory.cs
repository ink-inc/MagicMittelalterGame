using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PlayerProperties playerProperties;    

    private int slotsFilled;
    private List<InventoryItem> inventory;

    private void Start()
    {
        inventory = new List<InventoryItem>();
    }

    public bool Pickup(InventoryItem item)
    {
        if (CanPickup(item.weigth))
        {
            inventory.Add(item);
            slotsFilled++;
            playerProperties.SetWeight(playerProperties.GetWeight() + item.weigth);
            
            return true;
        }
        return false;
    }

    public bool CanPickup(float itemWeight)
    {
        //TODO: This is ugly... but it should work
        float weight = playerProperties.GetWeight();
        return (playerProperties.GetWeightCapacity() < 0 || weight + itemWeight <= playerProperties.GetWeightCapacity()) && (playerProperties.GetSlotCapacity() < 0 || slotsFilled <= playerProperties.GetSlotCapacity());
    }


    public void Drop(InventoryItem item)
    {
        //TODO: Method for dropping selected item
    }

    public void Equip(InventoryItem item)
    {
        //TODO: Method for equipping weapons and armor
    }
}