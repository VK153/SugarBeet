using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamedRatAttack : MonoBehaviour
{
    float dmg = 5;
    float spd = 5;
    GameObject player;
    Player atk;
    PlayerMovement pm;

    float per = 5,count;

    private void Start()
    {
        player = GameObject.Find("Player");
        atk = player.GetComponent<Player>();
        pm = player.GetComponent<PlayerMovement>();
        count = Random.Range(0, 100);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            atk.KnouckBack(transform.position, spd);
            atk.TakeAttack(dmg);
            if(per >= count)
            {
                pm.speed *= 0.3f;
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
