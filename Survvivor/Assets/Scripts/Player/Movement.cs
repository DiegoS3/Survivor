using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    public Joystick joystick;
    public Joystick joystickTurn;

    Vector2 movement;
   // Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        // Input
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;

        //Rotation for pc
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //Rotation for pc
        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle;

        float Haxis = joystickTurn.Horizontal;
        float Vaxis = joystickTurn.Vertical;
        float Zangle = Mathf.Atan2(Haxis, Vaxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, -Zangle);

    }

}
