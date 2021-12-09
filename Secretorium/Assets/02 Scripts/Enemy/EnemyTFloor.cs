using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class EnemyTFloor : MonoBehaviour
{
    public BoxCollider2D eTFloorB;
    private void Start()
    {
        eTFloorB = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("FloorEnemy"))
        {
            eTFloorB.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BaseEnemy"))
        {
            eTFloorB.isTrigger = false;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BaseEnemy"))
        {
            eTFloorB.isTrigger = false;
        }
    }
}
