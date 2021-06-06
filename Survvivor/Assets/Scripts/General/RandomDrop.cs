using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour
{
    private ItemDrop getItem;
    private float timeToRecreateObjects;
    private float minDrop = 6f;
    private float maxDrop = 12f;

    private void Start()
    {
        getItem = GetComponent<ItemDrop>();
        timeToRecreateObjects = Random.Range(minDrop, maxDrop);
    }

    void Update()
    {
        if (timeToRecreateObjects <= 0f)
        {
            getItem.DropItem();
            timeToRecreateObjects = Random.Range(minDrop, maxDrop);
        }
        else
        {
            timeToRecreateObjects -= Time.deltaTime;
        }
    }
}
