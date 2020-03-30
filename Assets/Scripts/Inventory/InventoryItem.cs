using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public delegate void ContextAction();

    public float weigth;
    public List<ContextAction> contextActions; //Holds all the action for clicking at an item -> Eat, Equip, Drop, etc.

    public virtual void Start()
    {
        contextActions = new List<ContextAction>();
        contextActions.Add(action_drop);
    }

    public void action_drop()
    {
        //TODO: Add Code for dropping item
    }
}