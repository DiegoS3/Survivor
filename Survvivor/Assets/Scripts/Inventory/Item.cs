using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Shotgun,
        MoreRate,
        MultiFire
    }

    public ItemType itemType;
    public float timeItem;
    //public int amount;

    public Item (ItemType itemType, float timeItem)
    {
        this.itemType = itemType;
        this.timeItem = timeItem;
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Shotgun:
                return ItemAssets.Instance.shotgun;
            case ItemType.MoreRate:
                return ItemAssets.Instance.moreRate;
            case ItemType.MultiFire:
                return ItemAssets.Instance.multiFire;

        }
    }

}
