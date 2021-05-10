using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy;

    private bool enemySpawned;
    private bool timerBool;

    private float timer;
    public float startTimer;

    
    void Start()
    {
        timer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == startTimer)
        {
            timerBool = true;
        }

        if(timerBool == true)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            timerBool = false;
            SpawnEnemy();
            timer = startTimer;
        }
    }
    private void SpawnEnemy()
    {
        enemySpawned = false;
        while (!enemySpawned)
        {
            Vector3 enemyPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 0f);
            if ((enemyPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(enemy, enemyPosition, Quaternion.identity);
                enemySpawned = true;
            }
        }
    }
}
