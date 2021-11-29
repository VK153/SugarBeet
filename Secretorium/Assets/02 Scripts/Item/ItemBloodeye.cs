using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBloodeye : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }

    private void OnDestroy()
    {
        if (player.GetComponent<ActionController>().getItem == true)
            player.GetComponentInChildren<WeaponFire>().upCri += 1;
        else if (player.GetComponent<ActionController>().getItem == false)
            player.GetComponent<Player>().scrap += 4;
    }
}
