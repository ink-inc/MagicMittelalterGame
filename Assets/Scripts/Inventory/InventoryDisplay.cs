using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;

    public GameObject UIObject;
    private InventoryItem[] items;

    [Header("GUI References")]
    public Transform slotParent;

    public GameObject slotPrefab;
    public GameObject toolTipMenu;

    public TextMeshProUGUI titleText;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI subNameText;
    public TextMeshProUGUI descriptionText;

    public Image iconLarge;

    public void Toggle()
    {
        if (UIObject.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Hide();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Show();
        }
    }

    public void Show()
    {
        UIObject.SetActive(true);
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

    public void Hide()
    {
        UIObject.SetActive(false);
        for (int i = 0; i < items.Length; i++)
        {
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