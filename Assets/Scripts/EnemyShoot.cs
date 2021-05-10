using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float enemyBulletSpeed;

    public Transform enemyFirePoint;
    public GameObject enemyBullet;

    public float enemyFireRate;
    public float enemyStartRate;

    public bool enemyFireCheck;
   
    [SerializeField] private string targetName; 
    [SerializeField] private float offset;
    [SerializeField] private float lerpSpeed;
    private Transform target;

    void Start()
    {
        target = GameObject.Find(targetName).transform;
    }
    
    void Update()
    {
        if (enemyFireCheck == true)
        {
            enemyFireRate -= Time.deltaTime;

            if (enemyFireRate <= 0)
            {
                enemyFireCheck = false;
            }
        }
        if (enemyFireRate <= 0)
        {
            EnemyFire();
        }
    }

    private void FixedUpdate()
    {
        TurnToTarget();
    }

    void TurnToTarget()
    {
        Vector3 pos = target.position - transform.position;
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle + offset)), lerpSpeed * Time.deltaTime);
    }

    public void EnemyFire()
    {
        enemyFireRate = enemyStartRate;
        enemyFireCheck = true;
        Instantiate(enemyBullet, enemyFirePoint.position, enemyFirePoint.rotation);
    }      
}
