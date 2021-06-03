using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellEmpty : MonoBehaviour
{
    public GameObject[] shellPrefab;
    public Transform[] shellOrigin;
    private float ejectionForce;
    private float ejectionTorque;
    private float shellLifetime;

    public void EjectShell()
    {
        int rand = Random.Range(0, 1);
        shellLifetime = Random.Range(2f, 4f);
        ejectionTorque = Random.Range(1f, 10f);
        ejectionForce = Random.Range(0.01f, .1f);

        // "Quaternion.identity" means default rotation
        GameObject newShell = Instantiate(shellPrefab[rand], shellOrigin[rand].position, Quaternion.identity);
        Rigidbody2D newShellBody = newShell.GetComponent<Rigidbody2D>();

        newShellBody.AddForce(shellOrigin[rand].right * ejectionForce, ForceMode2D.Impulse); // use red axis for direction
        newShellBody.AddTorque(ejectionTorque * Random.value, ForceMode2D.Impulse); // randomized torque

        Destroy(newShell, shellLifetime);
    }
}
