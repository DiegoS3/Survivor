using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint, AimOrigin;
    public Joystick joystick;

    public float bulletForce = 20f;
    public float fireRate = 0.4f;
    private float timeUntilNextShoot;

    private Player.AbilityType abilityType;

    private void Start()
    {
        abilityType = Player.Instance.GetAbilityType();
    }

    private void Update()
    {
        Vector2 dir = new Vector2(joystick.Horizontal, joystick.Vertical);
        //if (Input.GetButtonDown("Fire1") && timeUntilNextShoot < Time.time)
        if (dir != Vector2.zero && timeUntilNextShoot < Time.time)
        {
            abilityType = Player.Instance.GetAbilityType();
            switch (abilityType)
            {
                case Player.AbilityType.Shotgun:
                    ShotGun(20f, 3);
                    break;
                case Player.AbilityType.MultiFire:
                    ShotGun(360f, 9);
                    break;
                case Player.AbilityType.Simple:
                    Shoot();
                    break;
                case Player.AbilityType.MoreRate:
                    fireRate = 0.2f;
                    Shoot();
                    break;
            }
            timeUntilNextShoot = Time.time + fireRate;
            GetComponent<ShellEmpty>().EjectShell();
        }
    }

    private void Shoot()
    {
        //PC
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 5.23f;

        //Vector3 currentPos = Camera.main.WorldToScreenPoint(firePoint.position);
        //mousePos.x = mousePos.x - currentPos.x;
        //mousePos.y = mousePos.y - currentPos.y;

        //float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        //Quaternion rotation =  Quaternion.Euler(new Vector3(0f, 0f, angle));

        float Haxis = joystick.Horizontal;
        float Vaxis = joystick.Vertical;
        float Zangle = Mathf.Atan2(Haxis, Vaxis) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, -Zangle));

        Instantiate(bulletPrefab, firePoint.position, rotation);
    }

    private void ShotGun(float spreadAngle, int bulletsAmount)
    {
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 5.23f;

        //Vector3 currentPos = Camera.main.WorldToScreenPoint(firePoint.position);
        //mousePos.x = mousePos.x - currentPos.x;
        //mousePos.y = mousePos.y - currentPos.y;

        float Haxis = joystick.Horizontal;
        float Vaxis = joystick.Vertical;

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
            //if (mousePos.x == -1 && mousePos.y == 0)
            if (Haxis == -1 && Vaxis == 0)
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
    }
}
