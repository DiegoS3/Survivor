using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyable : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sprites;

    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private int numSprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.enabled = false;
        numSprite = 0;
        spriteRenderer.sprite = sprites[numSprite];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            if (numSprite < sprites.Length - 1)
            {
                numSprite++;
                spriteRenderer.sprite = sprites[numSprite];
                numSprite++;
                spriteRenderer.sprite = sprites[numSprite];
            }
            else
            {
                anim.enabled = true;
                Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length);
            }
        }
    }

}
