using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 15f;

    [SerializeField]
    private GameObject hitEffect;

    [SerializeField]
    private int damage = 1;

    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement = transform.right * speed;
        rb.velocity = movement;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().UpdateHealth(damage);         
        }

        Destroy(effect, .2f);
        Destroy(gameObject);
    }

}
