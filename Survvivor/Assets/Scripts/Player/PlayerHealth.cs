using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health = 0f;

    [SerializeField]
    private float maxHealth = 3f;

    private void Start()
    {
        health = maxHealth;
    }

    public void UpdateHealth(float cant)
    {
        health += cant;

        if (health > maxHealth)
        {
            health = maxHealth;
            Debug.Log("Vida Modificada");
        } 
        else if(health <= 0)
        {
            health = 0f;
            Debug.Log("Player death");
        }
    }
}
