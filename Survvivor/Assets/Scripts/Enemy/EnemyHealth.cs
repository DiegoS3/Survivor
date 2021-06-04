using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health = 0f;

    [SerializeField]
    private float maxHealth = 3f;

    private Animator anim;
    private ItemDrop getItem;

    private void Start()
    {
        health = maxHealth;
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

         if (health <= 0)
        {
            anim.SetBool("Dead", true);
            if (getItem != null)
            {
                getItem.DropItem();
            }
            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);

        }
    }
}
