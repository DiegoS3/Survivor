using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            anim.SetBool("Pick", true);
            PlayerStats.Instance.UpdateCoins();
            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
