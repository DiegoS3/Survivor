using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{

    [SerializeField]
    private GameObject[] spawns;

    [SerializeField]
    private GameObject[] spawnsPoints;

    [SerializeField]
    private GameObject enemy;

    private Animator[] anim;

    [SerializeField]
    private int numEnemiesSpawn;

    [SerializeField]
    private float timeNewSpawn;

    private float timeEndAnimSpawn = 0.45f;

    public float respawnTime;

    public bool spawn;

    private void Start()
    {
        StartBattle();
        spawn = false;
    }
    private void StartBattle()
    {
        anim = new Animator[spawns.Length];
        for (int i = 0; i < spawns.Length; i++)
        {
            anim[i] = spawns[i].GetComponent<Animator>();
      
            //anim[i].SetBool("Play", true);
        }
    }

    private void Update()
    {

        SpawnSpawner();
        if (anim[0].GetCurrentAnimatorStateInfo(0).normalizedTime >= timeEndAnimSpawn)
            for (int i = 0; i < numEnemiesSpawn; i++)
            {
                Invoke("SpawnEnemy", 1f);
            }
       
    }

    private void SpawnSpawner()
    {
        if (anim != null)
        {
            for (int i = 0; i < anim.Length; i++)
            {
                anim[i].SetBool("Play", true);
                //if (anim[i].GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                //{
                //    anim[i].SetBool("Play", false);
                //    anim[i].SetBool("Spawning", false);
                //}
            }
        }
    }

    private void HideSpawn()
    {
        for (int i = 0; i < anim.Length; i++)
        {
            anim[i].SetBool("Play", false);
            anim[i].SetBool("Spawning", false);
        }
    }

    private void SpawnEnemy()
    {
        if (anim != null)
        {
            //for (int i = 0; i < anim.Length; i++)
            //{

                //if (anim[i].GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    anim[0].SetBool("Play", false);
                    anim[0].SetBool("Spawning", true);
            StartCoroutine(SpawningEnemy());
                
            //}
        }
    }
    
    IEnumerator SpawningEnemy()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(respawnTime);
            Instantiate(enemy, spawnsPoints[0].transform.position, Quaternion.identity);
        }
    }
}
