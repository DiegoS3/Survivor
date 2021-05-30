using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets : MonoBehaviour
{

    [SerializeField]
    private Transform firePoint, AimOrigin;

    [SerializeField]
    private bool single, shotgun;

    [SerializeField]
    private float coolDown, attackSpeed = 0.2f, projectileSpread;

    public GameObject bulletPrefab;

    public bool idle;

    public static FireBullets fireBulletInstance;

    private void Awake()
    {
        fireBulletInstance = this;
    }

    void Start()
    {
        single = true;
        shotgun = false;
        idle = true;
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Time.time >= coolDown)
        {
            if (Input.GetButtonDown("Fire1") && !idle)
            {
                if (single) Fire();
                else if (shotgun) ShotGun(20f, 3);
                else MultiFire(0, 360, 9);
                    
            }
        }
    }

    private void Fire()
    {
        Vector2 shootingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(shootingDirection * 20f, ForceMode2D.Impulse);
        bullet.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
        coolDown = Time.time + attackSpeed;
    }

    private void ShotGun(float spreadAngle, int bulletsAmount)
    {
        Vector2 shootingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float angleStep = spreadAngle / bulletsAmount;
        float aimingAngle = AimOrigin.rotation.eulerAngles.z;
        float centeringOffset = (spreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is    
        

        for (int i = 0; i < bulletsAmount; i++)
        {
            float currentBulletAngle = angleStep * i;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet;
            Rigidbody2D rb;

            //Para disparar hacia la izquierda recto
            if (shootingDirection.x == -1 && shootingDirection.y == 0)
            {
                var shotRotDeg = -180;
                var offsetX = -0.55f;
                var offsetY = 0.12f;
                Vector3 offset = new Vector3(offsetX, offsetY, 0);
                bullet = Instantiate(bulletPrefab, firePoint.transform.position + offset, rotation);
                bullet.transform.Rotate(0, 0, shotRotDeg);
            }
            else //Disparar en cualquier otra direccion
            {
                bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            }

            rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(bullet.transform.right * 20f, ForceMode2D.Impulse);

        }
        coolDown = Time.time + attackSpeed;
    }

    private void MultiFire(float startAngle, float endAngle, int bulletsAmount)
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;
        Vector2 shootingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        for (int i = 0; i < bulletsAmount; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = firePoint.position;
            bul.transform.rotation = firePoint.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            bul.GetComponent<Bullet>().transform.Rotate(0.0f, 0.0f, - Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);

            angle += angleStep;
            coolDown = Time.time + attackSpeed;

        }
        coolDown = Time.time + attackSpeed;
    }
}

