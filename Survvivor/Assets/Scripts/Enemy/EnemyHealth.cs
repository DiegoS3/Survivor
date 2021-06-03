using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private float health = 0f;

    [SerializeField]
    private float maxHealth = 3f;

    private Animator anim;

    private void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
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

            Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
            if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Death")) 
            {
            }
        }
    }
}
