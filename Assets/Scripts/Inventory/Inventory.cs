﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PlayerProperties playerProperties;
    public InventoryDisplay inventoryDisplay;

    private int slotsFilled;
    private List<InventoryItem> inventory;

    private void Start()
    {
        inventory = new List<InventoryItem>();
    }

    public InventoryItem[] getItems()
    {
        return inventory.ToArray();
    }

    public bool Pickup(InventoryItem item)
    {
        if (CanPickup(item.weigth))
        {
            inventory.Add(item);
            slotsFilled++;
            playerProperties.SetWeight(playerProperties.GetWeight() + item.weigth);
            playerProperties.CalculateSpeed();
            return true;
        }
        return false;
    }

    public bool CanPickup(float itemWeight)
    {
        return true; //REMOVE AFTERWARDS
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryDisplay.Toggle();
        }
    }
}