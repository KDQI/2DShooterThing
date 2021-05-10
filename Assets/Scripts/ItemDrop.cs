using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDrop : MonoBehaviour
{
    public Text CommonText;
    public Text RareText;
    public Text EpicText;

    public int CommonCount;
    public int RareCount;
    public int EpicCount;

    public PlayerShooting ps;
    public PlayerHealtManager ph;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Common"))
        {
            ps.currentBullets += 10;
            CommonCount++;
            CommonText.text = CommonCount.ToString() + " Commons";
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Rare"))
        {
            ph.health = ph.maxHealth;
            RareCount++;
            RareText.text = RareCount.ToString() + " Rares";
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Epic"))
        {
            ps.maxBullets += 5;
            ph.maxHealth += 1;
            EpicCount++;
            EpicText.text = EpicCount.ToString() + " Epics";
            Destroy(col.gameObject);
        }
    }

    
}
