using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealtManager : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int dmgToTake;

    public Text hp;

    public GameObject damagePanel;

    bool timerBool;
    float timer;
    float startTimer = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        timer = startTimer;
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = health.ToString() + " HP";

        if (health >= maxHealth)
        {
            health = maxHealth;
        }

        if(health <= 0)
        {
            Die();
        }
        
        if(timerBool == true)
        {
            timer -= Time.deltaTime;

              if(timer <= 0)
            {
                damagePanel.SetActive(false);
                timerBool = false;
            }
        }
        else
        {
            timer = startTimer;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnemyAmmo"))
        {
            damagePanel.SetActive(true);
            timerBool = true;
            health--;
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
