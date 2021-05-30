using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLook : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        Vector2 shootingDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.right = shootingDirection;        
    }
}
