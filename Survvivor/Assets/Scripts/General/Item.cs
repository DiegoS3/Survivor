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

    private ItemType itemType;
    //public int amount;

    public Item (ItemType itemType)
    {
        this.itemType = itemType;
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
