using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    private bool add = false;

    public Inventory()
    {
        itemList = new List<Item>();

        //AddItem(new Item { itemType = Item.ItemType.MoreRate, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.Shotgun, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.MultiFire, amount = 1 });

        Debug.Log("Inventory");
    }

    public void AddItem(Item item)
    {
        if (itemList.Count > 0)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                if (!itemList[i].Equals(item))
                {
                    itemList.Add(item);
                    add = true;
                }
            }
        }
        else
        {
            itemList.Add(item);
            add = true;
        }

        if (add)
        {

            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }
        
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

}
