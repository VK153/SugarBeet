using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.CompareTag("EJumpTile"))
        {
            enemy.canJump = true;
            Debug.Log("붕붕");
        }
        else
        {
            enemy.canJump = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EJumpTile"))
        {
            enemy.canJump = false;
        }
    }
}
