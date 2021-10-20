using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkiShild : MonoBehaviour
{
    int hp = 1;

    private void Start()
    {
        GetComponentInParent<Enemy>().shild = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hp--;
            Destroy(collision.gameObject);
            if (hp < 0)
            {
                GetComponentInParent<Enemy>().shild = false;
                Destroy(gameObject);
            }
        }
    }
}
