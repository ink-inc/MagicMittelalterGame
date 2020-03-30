using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : InventoryItem
{
    public float healthValue;

    public override void Start()
    {
        base.Start();
        contextActions.Add(action_eat);
    }

    public void action_eat()
    {
        //TODO: Add code for eating
    }
}