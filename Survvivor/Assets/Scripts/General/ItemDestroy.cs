using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroy : MonoBehaviour
{
    private float randTime;
    private float currentTime;
    private float minimum = 0.0f;
    private float maximum = 1f;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        randTime = Random.Range(2f, 4f);
        currentTime = Time.time;
        StartCoroutine(SelfDestruct());
    }

    private void Update()
    {
        float t = (Time.time - currentTime) / randTime;
        sr.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(randTime);
        Destroy(gameObject);
    }
}
