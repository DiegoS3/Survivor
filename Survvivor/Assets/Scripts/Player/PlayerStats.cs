using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public static PlayerStats Instance { get; private set; }

    private float health = 0f;
    private int coins;
    private int enemies;
    private float time;
    private TimeSpan timeCrono;
    private bool muerto;

    [SerializeField]
    private Text crono, coinCounter, enemyCounter, heartCounter;

    [SerializeField]
    private float initHealth = 3f;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        health = initHealth;
        coins = 0;
        enemies = 0;
        time = 0f;
        crono.text = "00:00";
        muerto = false;
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
            muerto = true;
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
        enemies += cant;
    }

    private IEnumerator LifeTimePlayer()
    {
        while(!muerto)
        {
            time += Time.deltaTime;
            timeCrono = TimeSpan.FromSeconds(time);
            string timeCronoStr = "" + timeCrono.ToString(@"mm\:ss");
            crono.text = timeCronoStr;
            yield return null;
        }
    }
}
