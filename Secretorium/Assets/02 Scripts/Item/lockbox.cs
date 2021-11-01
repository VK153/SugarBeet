using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockbox : MonoBehaviour
{
    Player pl;
    Transform tr;

    public GameObject p_pills;
    public GameObject p_sugarbeat;
    public GameObject a_happyGrenade;
    public GameObject a_timeStop;
    public GameObject a_inFact;
    public GameObject a_chaserTicket;
    public GameObject a_invisivlePotion;
    void Start()
    {
        pl = GameObject.Find("Player").GetComponent<Player>();
        tr = GetComponent<Transform>();
    }
    public void Unlocked()
    {
        float a = Random.Range(0, 100);
        if (a < 8.5f)
        {
            Instantiate(p_pills, tr.position, Quaternion.identity);
        }
        else if (8.5 <= a && a < 13.5f)
        {
            if (pl.sugarBeat == false)
                Instantiate(p_sugarbeat, tr.position, Quaternion.identity);
            else
                pl.scrap += 10;
        }
        else if (13.5f <= a && a < 18.5f)
        {
            Instantiate(a_happyGrenade, tr.position, Quaternion.identity);
        }
        else if (18.5f <= a && a < 26)
        {
            Instantiate(a_timeStop, tr.position, Quaternion.identity);
        }
        else if (26 <= a && a < 38.5f)
        {
            Instantiate(a_inFact, tr.position, Quaternion.identity);
        }
        else if (38.5f <= a && a < 51)
        {
            Instantiate(a_chaserTicket, tr.position, Quaternion.identity);
        }
        else if (51 <= a && a < 66)
        {
            Instantiate(a_invisivlePotion, tr.position, Quaternion.identity);
        }
        else if (66 <= a && a < 66.25)
        {
            pl.scrap += 1;
        }
        else if (66.25 <= a && a < 73.5f)
        {
            pl.scrap += 2;
        }
        else if (73.5f <= a && a < 98.5f)
        {
            pl.scrap += 5;
        }
        else if (98.5f <= a)
        {
            pl.scrap += 10;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit") && Input.GetKeyDown(KeyCode.E) /*&& pl.key >= 1*/)
        {
            //pl.key -= 1;
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Unlocked();
    }
}
