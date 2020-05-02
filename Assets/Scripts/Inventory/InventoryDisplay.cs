using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public enum InventorySortMethod { NAME, WEIGHT, CATEGORY }

[AddComponentMenu("Inventory/InventoryDisplay")]
public class InventoryDisplay : CloseableMenu
{
    [Header("Settings")]
    public PlayerProperties playerProperties;

    public Inventory inventory;
    public InventorySortMethod sortMethod = InventorySortMethod.NAME;
    public bool sortDescending = false;

    private InventoryItem[] items;

    [Header("GUI References")]
    public Transform slotParent;

    public GameObject slotPrefab;
    public InventoryContextMenu menu;

    public TextMeshProUGUI titleText;

    [Header("GUI References/Detail View")]
    public Image iconLarge;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI subNameText;
    public TextMeshProUGUI descriptionText;
    public TMP_Dropdown sortDropDown;

    [Header("GUI References/Info Bar")]
    public TextMeshProUGUI slotText;

    public TextMeshProUGUI weightText;
    public Gradient weightTextGradient;

    public override void Show()
    {
        base.Show();
        RefreshDisplay();
        DisplayDetails(-1);
    }

    public override void Hide()
    {
        base.Hide();
        for (int i = 0; i < items.Length; i++)
        {
            if (slotParent.GetChild(i) != null)
                Destroy(slotParent.GetChild(i).gameObject);
        }
    }

    public void DisplayDetails(int id)
    {
        if (menu.active)
            menu.Hide();
        if (id < 0 || id >= items.Length)
        {
            nameText.text = null;
            subNameText.text = null;
            descriptionText.text = null;
            iconLarge.sprite = null;
            iconLarge.enabled = false;
            return;
        }
        iconLarge.enabled = true;
        Logger.log("Showing id " + id);
        Logger.log("Object: " + items[id]);
        Logger.log("Name: " + items[id].name);
        nameText.text = items[id].name;
        subNameText.text = items[id].subname;
        descriptionText.text = items[id].description;
        iconLarge.sprite = items[id].icon;
    }

    public void CloseContextMenu()
    {
        if (menu.active)
            menu.Hide();
    }

    public void DisplayContext(int id)
    {
        Logger.log("Open context for id: " + id);
        if (menu.active)
            menu.Hide();
        menu.feed(items[id]);
        menu.Show();
    }

    public void RefreshDisplay()
    {
        items = inventory.GetItems();
        Logger.log("Items in inventory: " + items.Length);

        items = SortInventory(items);

        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(slotPrefab, slotParent);
            int ii = i;
            //instance.GetComponent<Button>().onClick.AddListener(() => displayDetails(ii));
            ButtonClick click = instance.GetComponent<ButtonClick>();
            click.leftClick.AddListener(() => DisplayDetails(ii));
            click.rightClick.AddListener(() => DisplayContext(ii));
            instance.GetComponent<InventorySlot>().Display(items[i]);
            Logger.log("Added listener with ID: " + i);
        }

        slotText.text = "Items: " + inventory.GetSlotsUsed() + "/" + playerProperties.slotCapacity;
        weightText.text = "Capacity: " + playerProperties.weight + "/" + playerProperties.weightCapacity;

        float gradientTime = playerProperties.GetSpeedPenaltyGradient() / 100;
        //Logger.log("Time: " + gradientTime);
        weightText.color = weightTextGradient.Evaluate(gradientTime);

        slotText.gameObject.SetActive(playerProperties.GetSlotCapacityEnabled());
        weightText.gameObject.SetActive(playerProperties.GetWeightCapacityEnabled()); //Only show texts if type capacity is enabled
    }

    public InventoryItem[] SortInventory(InventoryItem[] items)
    {
        return SortInventory(items, sortMethod, sortDescending);
    }

    private InventoryItem[] SortInventory(InventoryItem[] items, InventorySortMethod newMethod, bool invert = false)
    {
        for (int j = 0; j <= items.Length - 2; j++)
        {
            for (int i = 0; i <= items.Length - 2; i++)
            {
                if (IsGreater(items[i], items[i + 1]))
                {
                    InventoryItem temp = items[i + 1];
                    items[i + 1] = items[i];
                    items[i] = temp;
                }
            }
        }
        if (invert)
        {
            Array.Reverse(items);
        }
        return items;
    }

    private bool IsGreater(InventoryItem item1, InventoryItem item2) //Returns true, if item1 > item2
    {
        if (sortMethod == InventorySortMethod.WEIGHT)
        {
            return item1.GetWeight() > item2.GetWeight();
        }
        string value1, value2;
        switch (sortMethod)
        {
            case InventorySortMethod.CATEGORY:
                value1 = item1.GetType();
                value2 = item2.GetType();
                break;

            default:
                value1 = item1.name;
                value2 = item2.name;
                break;
        }
        return (value1.CompareTo(value2) > 0);
    }

    public void UpdateSortGUI()
    {
        switch (sortDropDown.value)
        {
            case 0:
                sortMethod = InventorySortMethod.NAME;
                sortDescending = false;
                break;

            case 1:
                sortMethod = InventorySortMethod.NAME;
                sortDescending = true;
                break;

            case 2:
                sortMethod = InventorySortMethod.CATEGORY;
                sortDescending = false;
                break;

            case 3:
                sortMethod = InventorySortMethod.CATEGORY;
                sortDescending = true;
                break;

            case 4:
                sortMethod = InventorySortMethod.WEIGHT;
                sortDescending = false;
                break;

            case 5:
                sortMethod = InventorySortMethod.WEIGHT;
                sortDescending = true;
                break;
        }
        Hide();
        Show();
    }
}