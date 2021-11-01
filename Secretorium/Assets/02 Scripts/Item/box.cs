using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public GameObject p_kittin;
    public GameObject p_bloodEye;
    public GameObject p_brokenGlass;
    public GameObject p_dicon;
    public GameObject p_sugar;
    public GameObject p_pills;
    public GameObject a_invisiblePotion;
    public GameObject a_timeStop;
    public GameObject a_happyGrenade;

    Transform tr;

    Player pl;

    private void Start()
    {
        pl = GameObject.Find("Player").GetComponent<Player>();
        tr = GetComponent<Transform>();
    }
    public void Unlocked()
    {
        float a = Random.Range(0, 100);

        if (a < 9)
        {
            Instantiate(p_kittin, tr.position, Quaternion.identity);
        }
        else if (9 <= a && a < 19)
        {
            Instantiate(p_bloodEye, tr.position, Quaternion.identity);
        }
        else if (19 <= a && a < 27)
        {
            Instantiate(p_brokenGlass, tr.position, Quaternion.identity);
        }
        else if (27 <= a && a < 39)
        {
            Instantiate(p_dicon, tr.position, Quaternion.identity);
        }
        else if (39 <= a && a < 47)
        {
            Instantiate(p_sugar, tr.position, Quaternion.identity);
        }
        else if (47 <= a && a < 51)
        {
            Instantiate(p_pills, tr.position, Quaternion.identity);
        }
        else if (51 <= a && a < 52.25f)
        {
            Instantiate(a_invisiblePotion, tr.position, Quaternion.identity);
        }
        else if (52.25f <= a && a < 53.5f)
        {
            Instantiate(a_timeStop, tr.position, Quaternion.identity);
        }
        else if (53.5f <= a && a < 54.75f)
        {
            Instantiate(a_happyGrenade, tr.position, Quaternion.identity);
        }
        else if (54.75f <= a && a < 60.5f)
        {
            pl.scrap += 1;
        }
        else if (60.5f <= a && a < 75.5f)
        {
            pl.scrap += 2;
        }
        else if (75.5f <= a && a < 97.5f)
        {
            pl.scrap += 3;
        }
        else if (97.5f <= a)
        {
            pl.scrap += 5;
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
