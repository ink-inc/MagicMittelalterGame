using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[AddComponentMenu("Inventory/InventoryDisplay")]
public class InventoryDisplay : CloseableMenu
{
    public PlayerProperties playerProperties;
    public Inventory inventory;

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

    [Header("GUI References/Info Bar")]
    public TextMeshProUGUI slotText;

    public TextMeshProUGUI weightText;
    public Gradient weightTextGradient;

    public override void Show()
    {
        base.Show();
        items = inventory.getItems();
        Logger.log("Items in inventory: " + items.Length);
        for (int i = 0; i < items.Length; i++)
        {
            GameObject instance = Instantiate(slotPrefab, slotParent);
            instance.GetComponent<Image>().sprite = items[i].icon;
            int ii = i;
            //instance.GetComponent<Button>().onClick.AddListener(() => displayDetails(ii));
            ButtonClick click = instance.GetComponent<ButtonClick>();
            click.leftClick.AddListener(() => displayDetails(ii));
            click.rightClick.AddListener(() => displayContext(ii));
            instance.GetComponent<InventorySlot>().Display(items[i]);
            Logger.log("Added listener with ID: " + i);
        }
        displayDetails(-1);
        refreshDisplay();
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

    public void displayDetails(int id)
    {
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

    public void displayContext(int id)
    {
        Logger.log("Open context for id: " + id);
        if (menu.active)
            menu.Hide();
        menu.feed(items[id]);
        menu.Show();
    }

    public void refreshDisplay()
    {
        slotText.text = "Items: " + inventory.GetSlotsUsed() + "/" + playerProperties.slotCapacity;
        weightText.text = "Capacity: " + playerProperties.weight + "/" + playerProperties.weightCapacity;

        float gradientTime = playerProperties.GetSpeedPenaltyGradient() / 100;
        Logger.log("Time: " + gradientTime);
        weightText.color = weightTextGradient.Evaluate(gradientTime);

        slotText.gameObject.SetActive(playerProperties.GetSlotCapacityEnabled());
        weightText.gameObject.SetActive(playerProperties.GetWeightCapacityEnabled()); //Only show texts if type capacity is enabled
    }
}