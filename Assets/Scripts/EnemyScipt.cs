using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScipt : MonoBehaviour
{
    public List<GameObject> reveal;

    public int[] table = { 400, 350, 250 };

    public int total;
    public int randomNumber;

    public float enemyHP = 1f;

    private PlayerShooting playerShooting;

    

    private void Start()
    {
        playerShooting = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>();
    }

    private void Update()
    {
        if(enemyHP <= 0)
        {
            ScoreSystem.instance.AddScore();
            Die();
        }
    }
 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("PlayerAmmo"))
        {
            enemyHP -= playerShooting.dmgToDeal;
            Destroy(col.gameObject);
        }
    }

    void Die()
    {
        
        RNG();
        Destroy(gameObject);
    }
    void RNG()
    {
        foreach (var item in table)
        {
            total += item;
        }
        randomNumber = Random.Range(0, total);

        for (int i = 0; i < table.Length; i++)
        {
            if (randomNumber <= table[i])
            {
                Instantiate(reveal[i], transform.position, Quaternion.identity);

                //reveal[i].SetActive(true);
                return;
            }
            else
            {
                randomNumber -= table[i];
            }
        }
    }
}

