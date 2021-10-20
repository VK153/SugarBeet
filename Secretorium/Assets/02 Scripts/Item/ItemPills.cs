using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPills : MonoBehaviour
{
    GameObject player;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("PlayerHit"))
    //    {
    //        player = collision.GetComponentInParent<Player>().gameObject;
    //        player.GetComponent<Player>().avoidPoint *= 1.05f;
    //        if(player.GetComponent<Player>().sugarBeat == false)
    //        {
    //            player.GetComponent<Player>().maxHp += 20;
    //            player.GetComponent<Player>().selfHeal += 1;
    //        }
    //        Destroy(gameObject);
    //    }
    //}

    private void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }

    private void OnDestroy()
    {
        if (player.GetComponent<ActionController>().getItem == true)
        {
            player.GetComponent<Player>().avoidPoint *= 1.05f;
            if (player.GetComponent<Player>().sugarBeat == false)
            {
                player.GetComponent<Player>().maxHp += 20;
                player.GetComponent<Player>().selfHeal += 1;
            }
        }
        else if(player.GetComponent<ActionController>().getItem == false)
        {
            player.GetComponent<Player>().scrap += 12;
        }
    }
}
