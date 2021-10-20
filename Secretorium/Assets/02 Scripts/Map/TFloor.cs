using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TFloor : MonoBehaviour
{
    public BoxCollider2D tFloorB;
    private void Start()
    {
        tFloorB = gameObject.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            tFloorB.isTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            tFloorB.isTrigger = false;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            tFloorB.isTrigger = false;
        }
    }
}
