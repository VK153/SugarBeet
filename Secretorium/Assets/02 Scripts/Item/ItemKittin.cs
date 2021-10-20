using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKittin : MonoBehaviour
{
    GameObject pl;

    private void Start()
    {
        pl = GameObject.Find("Player").gameObject;
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("PlayerHit"))
    //    {
    //        collision.GetComponentInParent<Player>().avoidPoint += collision.GetComponentInParent<Player>().avoidPoint * 0.2f;
    //        Destroy(gameObject);
    //    }
    //}

    private void OnDestroy()
    {
        if (pl.GetComponent<ActionController>().getItem == true)
            pl.GetComponent<Player>().avoidPoint += pl.GetComponent<Player>().avoidPoint * 0.2f;
        else if (pl.GetComponent<ActionController>().getItem == false)
            pl.GetComponent<Player>().scrap += 4;
    }
}
