using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField]
    private Transform[] itemSlotTemplate;

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
            itemSlotTemplate[slot].GetComponent<Button>().onClick.AddListener(() => inventory.UseItem(item));
            slot++;

        }
    }
}
