using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float checkRadius, attackRadius, speed;

    [SerializeField]
    private LayerMask whatIsPlayer;

    private Transform target;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 dir;
    private Vector2 movement;

    private bool isInChaseRange;
    private bool isInAttackRange;
    public float coolDownAttack = 1f;
    private float timeUntilNextShoot;
    private int attack;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
        attack = 1;
    }

    // Update is called once per frame
    void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        dir.Normalize();
        movement = dir;
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            anim.SetBool("Attack", false);
            MoveCharacter(movement);
        }
        if (isInAttackRange && timeUntilNextShoot < Time.time)
        {
            rb.velocity = Vector2.zero;
            Attack();
            timeUntilNextShoot = Time.time + coolDownAttack;
        }
    }

    private void MoveCharacter(Vector2 movement)
    {
        if (gameObject.GetComponent<EnemyHealth>().GetHealth() > 0f)
        {
            rb.MovePosition((Vector2)transform.position + (movement * speed * Time.fixedDeltaTime));
        }
    }

    private void Attack()
    {
        anim.SetBool("Attack", true);
        PlayerStats.Instance.UpdateHealth(-attack);    
    }
}
