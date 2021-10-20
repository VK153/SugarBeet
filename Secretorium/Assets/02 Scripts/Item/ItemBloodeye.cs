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
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("PlayerHit"))
    //    {
    //        player = collision.GetComponentInParent<Player>().gameObject;
    //        player.GetComponentInChildren<WeaponFire>().upCri += 0.01f;
    //        Destroy(gameObject);
    //    }
    //}

    private void OnDestroy()
    {
        if (player.GetComponent<ActionController>().getItem == true)
            player.GetComponentInChildren<WeaponFire>().upCri += 1/*player.GetComponentInChildren<WeaponFire>().upCri*0.01f*/;
        else if (player.GetComponent<ActionController>().getItem == false)
            player.GetComponent<Player>().scrap += 4;
    }
}
