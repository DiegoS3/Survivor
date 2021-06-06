using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLook : MonoBehaviour
{
    public Joystick joystick;
    
    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 5.23f;

        //Vector3 currentPos = Camera.main.WorldToScreenPoint(transform.position);
        //mousePos.x = mousePos.x - currentPos.x;
        //mousePos.y = mousePos.y - currentPos.y;

        //Vector2 shootingDirection = new Vector2(mousePos.x, mousePos.y);

        float Haxis = joystick.Horizontal;
        float Vaxis = joystick.Vertical;
        Vector2 shootingDirection = new Vector2(Haxis, Vaxis);
        transform.right = shootingDirection;        
    }
}
