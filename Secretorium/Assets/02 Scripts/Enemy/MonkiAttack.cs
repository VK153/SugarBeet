using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class MonkiAttack : MonoBehaviour
{
    float dmg = 30f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            collision.GetComponent<Player>().TakeAttack(dmg);
        }
    }
}
