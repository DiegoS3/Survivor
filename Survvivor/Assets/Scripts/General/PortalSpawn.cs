using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    public bool spawn, newSpawn;
    private Animator anim;
    private int numState;

    private bool stopSpawning = false;
    [SerializeField]
    private float waitTime = 2.5f;
    private List<GameObject> enemyList;
    [SerializeField]
    private int waveCount = 0;

    private int[] enemySpawnProb;

    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject enemyContainer;

    private string[] statesTag = new string[] { "Start", "Spawn", "End" };

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
        time = minRespawnTime;
        spawn = false;
        newSpawn = true;
        enemySpawnProb = new int[enemies.Length];
        enemyList = new List<GameObject>();
        numState = 0;
        SetRandomTime();
        StartCoroutine(PhaseManagmentRoutine());
    }

    private void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime && newSpawn)
        {
            //SpawnEnemy();
            SetRandomTime();
        }
    }

    //Sets the random time between minTime and maxTime
    private void SetRandomTime()
    {
        spawnTime = Random.Range(minRespawnTime, maxRespawnTime);
    }

    private IEnumerator PlayAndWaitForAnim()
    {

        //var stateName = statesTag[numState];

        //anim.Play(stateName, 1);

        //anim.enabled = !anim.enabled;
        anim.SetBool("Play", true);
        timeEndAnimSpawn = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        //Wait until we enter the current state
        while (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Start"))
        {
            yield return null;
        }

        //Now, Wait until the current state is done playing
        while ((anim.GetCurrentAnimatorStateInfo(0).normalizedTime) % 1 >= timeEndAnimSpawn)
        {
            yield return null;
        }
        StartCoroutine(SpawnWaveRoutine());
        //if (numState < statesTag.Length)
        //{
        //    numState++;
        //}
        //else
        //{
        //    numState = 0;
        //}

        //EndStepEvent();
    }

    private IEnumerator PhaseManagmentRoutine()
    {
        yield return new WaitForSeconds(3.5f);
        while (!stopSpawning)
        {
            yield return SpawnWaveRoutine();
            yield return new WaitWhile(EnemyIsAlive);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator SpawnWaveRoutine()
    {
        waveCount++;
        AssignProbability();
        for (int i = 0; i < waveCount; i++)
        {
            SpawnEnemy2();
            Invoke("spawn1", .1f);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SpawnEnemy2()
    {
        int randomEnemy = Random.Range(1, 101);
        int low;
        int high = 0;

        for (int i = 0; i < enemies.Length; i++)
        {
            low = high;
            high += enemySpawnProb[i];
            if (randomEnemy >= low && randomEnemy < high)
            {
                new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
                //float randomX = Random.Range(-9.5f, 9.5f);
                GameObject newEnemy = Instantiate(enemies[i], spawnPoint.position, Quaternion.identity);
                newEnemy.transform.parent = GameObject.Find("Enemy_Container").transform;
                enemyList.Add(newEnemy);
            }
        }
        //Invoke("end", anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }

    private bool EnemyIsAlive()
    {
        enemyList = enemyList.Where(e => e != null).ToList();
        return enemyList.Count > 0;
    }

    private void AssignProbability()
    {
        switch (waveCount)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                enemySpawnProb[0] = 65;
                enemySpawnProb[1] = 35;
                enemySpawnProb[2] = 10;
                enemySpawnProb[3] = 0;
                break;

            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                enemySpawnProb[0] = 45;
                enemySpawnProb[1] = 35;
                enemySpawnProb[2] = 20;
                enemySpawnProb[3] = 0;
                break;

            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
                enemySpawnProb[0] = 35;
                enemySpawnProb[1] = 35;
                enemySpawnProb[2] = 25;
                enemySpawnProb[3] = 5;
                break;

            case 15:
            case 16:
            case 17:
            case 18:
            case 19:
                enemySpawnProb[0] = 15;
                enemySpawnProb[1] = 15;
                enemySpawnProb[2] = 45;
                enemySpawnProb[3] = 25;
                break;
            
            case 20:
            case 21:
            case 22:
            case 23:
            case 24:
                enemySpawnProb[0] = 10;
                enemySpawnProb[1] = 10;
                enemySpawnProb[2] = 45;
                enemySpawnProb[3] = 35;
                break;

            default:
                enemySpawnProb[0] = 5;
                enemySpawnProb[1] = 5;
                enemySpawnProb[2] = 35;
                enemySpawnProb[3] = 55;
                break;
        }
    }



    //Spawns the object and resets the time
    private void SpawnEnemy()
    {
        spawn = true;
        anim.enabled = !anim.enabled;
        time = 0;
        //anim.SetBool("Play", true);

        anim.SetBool("Play", true);
        timeEndAnimSpawn = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        Invoke("spawn1", timeEndAnimSpawn);
        timeEndAnimSpawn = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        Invoke("end", timeEndAnimSpawn);

        //StartCoroutine(Test());
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

    private IEnumerator Test()
    {
        newSpawn = false;
        anim.SetBool("Play", true);
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        anim.SetBool("Play", false);
        anim.SetBool("Spawning", true);
        timeEndAnimSpawn = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        yield return new WaitForSeconds(timeEndAnimSpawn);
        Instantiate(enemy, spawnPoint.position, Quaternion.identity);
        //anim.SetBool("Play", false);
        anim.SetBool("Spawning", false);
        timeEndAnimSpawn = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        Debug.Log(timeEndAnimSpawn);
        yield return new WaitForSeconds(timeEndAnimSpawn);
        newSpawn = true;
    }

    private void start()
    {
        anim.SetBool("Play", true);
    }

    private void spawn1()
    {
        anim.SetBool("Play", false);
        anim.SetBool("Spawning", true);
        //Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }

    private void end()
    {
        anim.SetBool("Spawning", false);
    }

    private IEnumerator Test2()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length + anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        anim.SetBool("Play", false);
        anim.SetBool("Spawning", false);

    }

    

    private void EndStepEvent()
    {
        if (numState == 1)
        {
            anim.SetBool("Play", false);
            anim.SetBool("Spawning", true);
           // StartCoroutine(PlayAndWaitForAnim("Spawn"));
        }
        else if (numState == 2)
        {
            anim.SetBool("Play", false);
            anim.SetBool("Spawning", false);
            //StartCoroutine(PlayAndWaitForAnim("End"));
        }
    }
}
