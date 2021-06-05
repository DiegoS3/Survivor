using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health;
    private int score;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject player;

    private Animator anim;
    private ItemDrop getItem;


    private void Start()
    {
        health = maxHealth;
        Debug.Log(maxHealth);
        score = (int)maxHealth;
        Debug.Log(score);
        anim = GetComponent<Animator>();
        getItem = GetComponent<ItemDrop>();
    }

    public float GetHealth()
    {
        return health;
    }

    public void UpdateHealth(float cant)
    {
        health -= cant;

         if (health == 0)
        {
            anim.SetBool("Dead", true);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            if (gameObject != null)
            {
                player.GetComponent<PlayerStats>().UpdateEnemies(score);
            }
            if (getItem != null)
            {
                getItem.DropItem();
            }
            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
