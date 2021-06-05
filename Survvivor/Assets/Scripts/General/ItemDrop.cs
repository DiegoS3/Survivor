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

        if (randNum >= 96) //Drop multifire 4%
        {
            itemNum = 4;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
        else if (randNum > 88 && randNum < 96) //Drop life 8%
        {
            itemNum = 3;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
        else if (randNum > 76 && randNum <= 88)//Drop shotgun 12%
        {
            itemNum = 2;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
        else if (randNum > 60 && randNum <= 76)//Drop increment rate shoot 16%
        {
            itemNum = 1;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
        else if (randNum > 40 && randNum <= 60)//Drop coin 20%
        {
            itemNum = 0;
            Instantiate(itemList[itemNum], Epos.position, Quaternion.identity);
        }
    }
}
