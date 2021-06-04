using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemList; // Stores the game items

    private int itemNum; // Selects a number to choose from the itemList
    private int randNum; // chooses a random number to see if loot os dropped- Loot chance
    private Transform Epos; // enemy position

    private void Start()
    {
        Epos = GetComponent<Transform>();
    }

    public void DropItem()
    {
        randNum = Random.Range(0, 101); 

        if (randNum >= 95) //Drop multifire
        {
            itemNum = 4;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
        else if (randNum > 90 && randNum < 95) //Drop life
        {
            itemNum = 3;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
        else if (randNum > 75 && randNum <= 90)//Drop shotgun
        {
            itemNum = 2;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
        else if (randNum > 60 && randNum <= 75)//Drop increment rate shoot
        {
            itemNum = 1;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
        else if (randNum > 45 && randNum <= 60)//Drop coin
        {
            itemNum = 0;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
    }
}
