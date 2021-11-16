using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Transform enemyTr;
    Transform playerTr;
    Transform TileTr;
    Transform lastTr;
    public float tileX;
    public float playerX;
    public float enemyX;
    public float lastX;
    public float enemyY, lastY, playerY;
    public int spd = 5;
    public int dir;
    bool a = false, b = true,c=true,d=true;
    float nonT;



    // Start is called before the first frame update
    void Start()
    {
        lastTr = enemyTr;
        //lastX = GetComponentInParent<Enemy>().lax;
    }

    // Update is called once per frame
    void Update()
    {

        if (d == true)
        nonT += Time.deltaTime;
        if (nonT >= 0.3f)
            d = false;
        enemyTr = GetComponentInParent<Transform>();
        enemyX = enemyTr.position.x;
        enemyY = enemyTr.position.y;

        //Debug.Log(lastX);
        if (a == false && b ==false)
        {
            if (enemyX - lastX < -0.5f)
            {
                dir = -1;
                //오른쪽으로 이동
            }
            else if (enemyX - lastX > 0.5f)
            {
                dir = 1;
                //왼쪽으로 이동
            }
            else
            {
                dir = -1;
                b = true;
            }
        }
        if(b == true&& d==false)
        {
            if (c == true)
            {
                dir = -1;
                c = false;
            }
            patrol();
            GetComponentInParent<Enemy>().GoHome();
        }
        //Debug.Log(dir);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            playerTr = collision.GetComponent<Transform>();
            GetComponentInParent<Enemy>().playerTr = playerTr;
            GetComponentInParent<Enemy>().FInd = true;
            playerX = playerTr.position.x;
            playerY = playerTr.position.y;
            a = true;
            b = false;
        }
        else
        {
            return;
        }
        if (enemyX - playerX <= 0)   //조건이 맞을경우 오른쪽으로 가야함
        {
            dir = -1;
        }
        else
        {
            dir = 1;
        }
        if(enemyY - playerY < -3)
        {
            GetComponentInParent<Enemy>().isHigh = true;
        }
        else
        {
            GetComponentInParent<Enemy>().isHigh = false;
        }

        if(enemyY - playerY > 3)
        {
            GetComponentInParent<Enemy>().isLow = true;
        }
        else
        {
            GetComponentInParent<Enemy>().isLow = false;
        }
        //Debug.Log(collision);

        //if (collision.CompareTag("EJumpTile"))
        //{
        //    Debug.Log("둠칫");
        //    TileTr = collision.GetComponent<Transform>();
        //    tileX = TileTr.position.x;
        //    if (enemyX - tileX < 5 || enemyX - tileX > -5)
        //    {
        //        GetComponentInParent<Enemy>().canJump = true;
        //    }
        //    else
        //    {
        //        GetComponentInParent<Enemy>().canJump = false;
        //    }
        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            GetComponentInParent<Enemy>().FInd = false;
            dir = 0;
            a = false;
        }
        if (enemyX - lastX < 0)
        {
            dir = -1;
        }
        else if (enemyX == lastX)
        {
            dir = 0;
        }
        else
        {
            dir = 1;
        }
        
    }

    public void patrol()
    {
        if (enemyX >= lastX + 5f)
        {
            dir = 1;
        }
        else if(enemyX <= lastX - 5)
        {
            dir = -1;
        }
    }
}
