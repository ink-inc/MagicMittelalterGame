using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryDisplay : CloseableMenu
{
    public Inventory inventory;

    private InventoryItem[] items;

    [Header("GUI References")]
    public Transform slotParent;

    public GameObject slotPrefab;
    public GameObject toolTipMenu;

    public TextMeshProUGUI titleText;

    [Header("GUI References/Detail View")]
    public TextMeshProUGUI nameText;

    public TextMeshProUGUI subNameText;
    public TextMeshProUGUI descriptionText;

    public Image iconLarge;

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
            instance.GetComponent<Button>().onClick.AddListener(() => displayDetails(ii));
            instance.GetComponent<InventorySlot>().Display(items[i]);
            Logger.log("Added listener with ID: " + i);
        }
        displayDetails(-1);
    }

    public override void Hide()
    {
        base.Hide();
        for (int i = 0; i < items.Length; i++)
        {
            Destroy(slotParent.GetChild(i + 1).gameObject); //(i+1) to not hide the title row
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
            return;
        }
        Logger.log("Showing id " + id);
        Logger.log("Object: " + items[id]);
        Logger.log("Name: " + items[id].name);
        nameText.text = items[id].name;
        subNameText.text = items[id].subname;
        descriptionText.text = items[id].description;
        iconLarge.sprite = items[id].icon;
    }
}