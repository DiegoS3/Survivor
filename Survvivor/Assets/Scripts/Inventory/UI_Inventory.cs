using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    [SerializeField]
    private Transform[] itemSlotTemplate;

    private void Awake()
    {
        //itemSlotContainer = transform.Find("itemSlotContainer");
        //itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Invetory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void Invetory_OnItemListChanged(object sender, EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int slot = 0;

        foreach (Item item in inventory.GetItemList())
        {
            itemSlotTemplate[slot].GetComponent<RectTransform>();
            Image image = itemSlotTemplate[slot].Find("image").GetComponent<Image>();
            image.gameObject.SetActive(true);
            image.sprite = item.GetSprite();
            slot++;

        }
    }

}
