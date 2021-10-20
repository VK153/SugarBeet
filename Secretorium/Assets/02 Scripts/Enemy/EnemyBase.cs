using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor") || collision.CompareTag("EnemyTFloor"))
        {
            box.isTrigger = false;
        }
    }
}
