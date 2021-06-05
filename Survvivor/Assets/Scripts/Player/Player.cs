using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private Inventory inventory;

    [SerializeField]
    private UI_Inventory uiInventory;

    private AbilityType abilityType;

    private float timeItem;
    private bool usingItem;

    public enum AbilityType
    {
        Shotgun,
        MultiFire,
        Simple,
        MoreRate
    }

    private void Awake()
    {
        Instance = this;
        inventory = new Inventory(UseItem);
        uiInventory.SetInventory(inventory);
        abilityType = AbilityType.Simple;
    }

    private void Update()
    {
        if (usingItem)
        {
            timeItem -= Time.deltaTime;
            if (timeItem <= 0)
            {
                abilityType = AbilityType.Simple;
                usingItem = false;
            }
        }
        
    }

    public AbilityType GetAbilityType()
    {
        return abilityType;
    }

    private void UseItem(Item item)
    {
        uiInventory.CleanSlot(item);
        timeItem = item.timeItem;
        usingItem = true;
        switch (item.itemType)
        {
            case Item.ItemType.Shotgun:
                Debug.Log("Usada escopeta");
                abilityType = AbilityType.Shotgun;                
                inventory.RemoveItem(item);
                break;
            case Item.ItemType.MoreRate:
                Debug.Log("Usada rate");
                abilityType = AbilityType.MoreRate;
                inventory.RemoveItem(item);
                break;
            case Item.ItemType.MultiFire:
                Debug.Log("Usada fire");
                abilityType = AbilityType.MultiFire;
                inventory.RemoveItem(item);
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Coin":
                Destroy(collision.gameObject);
                gameObject.GetComponent<PlayerStats>().UpdateCoins();
                break;

            case "Heart":
                Destroy(collision.gameObject);
                gameObject.GetComponent<PlayerStats>().UpdateHealth(1);
                break;

            case "Shotgun":
                Item shotgun = new Item(Item.ItemType.Shotgun, 8.00f);                
                inventory.AddItem(shotgun);
                Destroy(collision.gameObject);
                break;

            case "MoreRate":
                Item moreRate = new Item(Item.ItemType.MoreRate, 10.00f);
                inventory.AddItem(moreRate);
                Destroy(collision.gameObject);
                break;

            case "MultiFire":
                Item multiFire = new Item(Item.ItemType.MultiFire, 5.00f);
                inventory.AddItem(multiFire);
                Destroy(collision.gameObject);
                break;
        }
    }
}
