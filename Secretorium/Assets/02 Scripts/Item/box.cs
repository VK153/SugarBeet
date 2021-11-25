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

        if (a < 12)
        {
            Instantiate(p_kittin, tr.position, Quaternion.identity);
        }
        else if (12 <= a && a < 27)
        {
            Instantiate(p_bloodEye, tr.position, Quaternion.identity);
        }
        else if (27 <= a && a < 40)
        {
            Instantiate(p_brokenGlass, tr.position, Quaternion.identity);
        }
        else if (40 <= a && a < 57)
        {
            Instantiate(p_dicon, tr.position, Quaternion.identity);
        }
        else if (57 <= a && a < 70)
        {
            Instantiate(p_sugar, tr.position, Quaternion.identity);
        }
        else if (70 <= a && a < 79)
        {
            Instantiate(p_pills, tr.position, Quaternion.identity);
        }
        else if (79 <= a && a < 86)
        {
            Instantiate(a_invisiblePotion, tr.position, Quaternion.identity);
        }
        else if (86 <= a && a < 93)
        {
            Instantiate(a_timeStop, tr.position, Quaternion.identity);
        }
        else if (93 <= a)
        {
            Instantiate(a_happyGrenade, tr.position, Quaternion.identity);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit") && Input.GetKeyDown(KeyCode.E) && pl.scrap >= 5)
        {
            pl.scrap -= 5;
            Unlocked();
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        
    }
}
