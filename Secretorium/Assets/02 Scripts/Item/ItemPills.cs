using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPills : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }

    private void OnDestroy()
    {
        if (player.GetComponent<ActionController>().getItem == true)
        {
            player.GetComponent<Player>().avoid *= 1.05f;
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
