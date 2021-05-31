using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private int numEnemiesSpawn;

    [SerializeField]
    private float timeNewSpawn;

    public float minRespawnTime = 2f, maxRespawnTime = 5f, timeEndAnimSpawn = 0.2f, time, spawnTime;
    public bool spawn;
    private Animator anim;
    private int numState;

    private string[] statesTag = new string[] { "Start", "Spawn", "End" };

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        time = minRespawnTime;
        spawn = false;
        numState = 0;
        SetRandomTime();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            SpawnEnemy();
            SetRandomTime();
        }
    }

    //Sets the random time between minTime and maxTime
    private void SetRandomTime()
    {
        spawnTime = Random.Range(minRespawnTime, maxRespawnTime);
    }

    //Spawns the object and resets the time
    private void SpawnEnemy()
    {
        spawn = true;
        anim.enabled = !anim.enabled;
        time = 0;
        //anim.SetBool("Play", true);

        StartCoroutine(PlayAndWaitForAnim("Start"));
        //if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= timeEndAnimSpawn &&
        //    anim.GetCurrentAnimatorStateInfo(0).IsTag("Start"))
        //{
        //    anim.SetBool("Play", false);
        //    anim.SetBool("Spawning", true);

        //    Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        //    anim.SetBool("Play", false);
        //    anim.SetBool("Spawning", false);
        //}

        //anim.enabled = !anim.enabled;
    }

    private IEnumerator PlayAndWaitForAnim(string stateName)
    {

            //var stateName = statesTag[numState];

            anim.Play(stateName, 1);

            //Wait until we enter the current state
            while (!anim.GetCurrentAnimatorStateInfo(0).IsTag(stateName))
            {
                yield return null;
            }

            //Now, Wait until the current state is done playing
            while ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 < 0.99f)
            {
                yield return null;
            }

        if (numState < statesTag.Length)
        {
            numState++;
        }
        else
        {
            numState = 0;
        }

        EndStepEvent();
    }

    private void EndStepEvent()
    {
        if (numState == 1)
        {
            anim.SetBool("Play", false);
            anim.SetBool("Spawning", true);
            StartCoroutine(PlayAndWaitForAnim("Spawn"));
        }
        else if (numState == 2)
        {
            anim.SetBool("Play", false);
            anim.SetBool("Spawning", false);
            StartCoroutine(PlayAndWaitForAnim("End"));
        }
    }
}
