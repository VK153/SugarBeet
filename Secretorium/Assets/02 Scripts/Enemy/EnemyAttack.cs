using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
    Player atk;
    public float spd = 30f;

    public float dmg = 10;
    private void Start()
    {
        player = GameObject.Find("Player");
        atk = player.GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit") /*&& GetComponentInChildren<EnemyFollow>().atk == true*/)
        {
            atk.KnouckBack(transform.position, spd);
            atk.TakeAttack(dmg);
        }
    }
}
