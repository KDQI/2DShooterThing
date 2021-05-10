using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public GameObject helpCanvas;
    public GameObject bullet;
    public Transform firePoint;

    public float fireRate;
    public float startFireRate;
    public bool fireRateBool;

    private float helpTimer;
    private float helpStartTimer = 5f;
    private bool helpTimerBool;

    public int dmgToDeal;

    public int maxBullets = 10;
    public int currentBullets;

    public Text BulletCountText;

    // Start is called before the first frame update
    void Start()
    {
        helpTimer = helpStartTimer;
        currentBullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        BulletCountText.text = currentBullets.ToString();


        if(currentBullets >= maxBullets)
        {
            currentBullets = maxBullets;
        }

        if (fireRateBool == true)
        {
            fireRate -= Time.deltaTime;

            if (fireRate <= 0)
            {
                fireRateBool = false;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (currentBullets >= 1)
            {
                if (fireRate <= 0)
                {
                    Fire();
                }
            }
            else
            {
                helpCanvas.SetActive(true);
                helpTimerBool = true;
            }
        }

        if (helpTimerBool == true)
        {
            helpTimer -= Time.deltaTime;
        }

        if (helpTimer <= 0)
        {
            helpTimerBool = false;
            helpCanvas.SetActive(false);
            helpTimer = helpStartTimer;
        }
    }

    public void Fire()
    {
        currentBullets--;
        fireRate = startFireRate;
        fireRateBool = true;
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
