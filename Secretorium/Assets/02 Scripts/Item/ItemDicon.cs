using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class ItemDicon : MonoBehaviour
{
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player").gameObject;
    }
    private void OnDestroy()
    {
        if (player.GetComponent<ActionController>().getItem == true)
            player.GetComponentInChildren<WeaponFire>().baseDmg *= 1.3f;
        else if (player.GetComponent<ActionController>().getItem == false)
            player.GetComponent<Player>().scrap += 4;
    }
}
