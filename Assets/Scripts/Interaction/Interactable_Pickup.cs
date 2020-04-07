﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Pickup : Interactable
{
    public InventoryItem itemToPickup;
    public Inventory inventory;

    public override void interact()
    {
        itemToPickup.gameObject.SetActive(!inventory.Pickup(itemToPickup));
    }
}