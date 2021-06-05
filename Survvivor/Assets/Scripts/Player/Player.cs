using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField]
    private UI_Inventory uiInventory;

    private GameObject obj;

    private void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Coin":
                Debug.Log("Moneda");
                Destroy(collision.gameObject);
                break;

            case "Heart":
                Debug.Log("Corazon");
                Destroy(collision.gameObject);
                break;

            case "Shotgun":
                Item shotgun = new Item(Item.ItemType.Shotgun);
                
                inventory.AddItem(shotgun);
                Debug.Log("Shotgun");
                Destroy(collision.gameObject);
                break;

            case "MoreRate":
                Item moreRate = new Item(Item.ItemType.MoreRate);
                inventory.AddItem(moreRate);
                Debug.Log("MoreRate");
                Destroy(collision.gameObject);
                break;

            case "MultiFire":
                Item multiFire = new Item(Item.ItemType.MultiFire);
                inventory.AddItem(multiFire);
                Debug.Log("MultiFire");
                Destroy(collision.gameObject);
                break;
        }
    }
}
