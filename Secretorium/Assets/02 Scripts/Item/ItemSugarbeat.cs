using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSugarbeat : MonoBehaviour
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
            if (player.GetComponent<Player>().sugarBeat == false)
            {
                player.GetComponent<Player>().hp = 1;
                player.GetComponent<Player>().sugarBeat = true;
                player.GetComponent<Player>().shield = 20000;
                player.GetComponentInChildren<WeaponFire>().bonusDmg = 30;
                player.GetComponent<Player>().selfHeal = 0;
            }
        }
    }
}
