using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBrokenGlass : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player").gameObject;
        Debug.Log("asdf");
    }
    private void OnDestroy()
    {
        if (player.GetComponent<ActionController>().getItem == true)
        {
            if (player.GetComponentInChildren<WeaponFire>().critical < 100)
            {
                player.GetComponentInChildren<WeaponFire>().critical += 10;
            }
        }
        else if(player.GetComponent<ActionController>().getItem == false)
        {
            player.GetComponent<Player>().scrap += 4;
        }
    }
}
