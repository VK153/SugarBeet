using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    GameObject player;
    Player atk;
    Animator eAnimator;
    public float spd = 30f;

    public float dmg = 10;
    private void Start()
    {
        eAnimator = GetComponentInParent<Animator>();
        player = GameObject.Find("Player");
        atk = player.GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            eAnimator.SetTrigger("Attack");
            atk.KnouckBack(transform.position, spd);
            atk.TakeAttack(dmg);
        }
    }
}
