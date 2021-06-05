using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private float health = 0f;
    private int coins;
    private int enemies;
    private float time;
    private TimeSpan timeCrono;

    [SerializeField]
    private Text crono, coinCounter, enemyCounter, heartCounter;

    [SerializeField]
    private float initHealth = 3f;

    private void Start()
    {
        health = initHealth;
        coins = 0;
        enemies = 0;
        time = 0f;
        crono.text = "00:00";
        coinCounter.text = coins.ToString();
        enemyCounter.text = enemies.ToString();
        heartCounter.text = health.ToString();
        StartCoroutine(LifeTimePlayer());
    }

    private void Update()
    {
        coinCounter.text = coins.ToString();
        enemyCounter.text = enemies.ToString();
        heartCounter.text = health.ToString();
    }

    public void UpdateHealth(float cant)
    {
        health += cant;

        if(health <= 0)
        {
            health = 0f;
            StopCoroutine(LifeTimePlayer());
            Debug.Log("Player death");
        }
    }

    public void UpdateCoins()
    {
        coins++;
    }

    public void UpdateEnemies(int cant)
    {

        Debug.Log("Actu ");
        enemies += cant;
        Debug.Log("Cantidad " + cant);
        Debug.Log("Muertes " + enemies);
    }

    private IEnumerator LifeTimePlayer()
    {
        while(health > 0)
        {
            time += Time.deltaTime;
            timeCrono = TimeSpan.FromSeconds(time);
            string timeCronoStr = timeCrono.ToString(@"mm\:ss");
            yield return null;
        }
    }
}
