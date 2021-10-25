using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAttack : MonoBehaviour
{
    float dmg = 5;
    float spd = 5;
    GameObject player;
    Player atk;

    private void Start()
    {
        player = GameObject.Find("Player");
        atk = player.GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            atk.KnouckBack(transform.position, spd);
            atk.TakeAttack(dmg);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
