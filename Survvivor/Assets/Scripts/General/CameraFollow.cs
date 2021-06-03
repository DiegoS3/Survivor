using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float cameraDistance = 100f;

    private void Awake()
    {
        GetComponent<Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
