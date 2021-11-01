using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHB : MonoBehaviour
{
    public GameObject gg;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            collision.GetComponentInParent<Player>().hp += collision.GetComponentInParent<Player>().maxHp * 0.1f;
        }
        else if (collision.CompareTag("GunFollow"))
        {
            collision.GetComponent<Enemy>().hp += collision.GetComponent<Enemy>().maxHp * 0.1f;
        }
        Destroy(gg.gameObject);
    }
}
