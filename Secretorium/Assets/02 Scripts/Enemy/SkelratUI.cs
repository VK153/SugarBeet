using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class SkelratUI : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject firePos;
    GameObject follow;

    Transform myTr;
    Transform playerTr;
    float myX, playerX, totalX;

    float mid,speed,look;

    float power = 250;

    float time = 0, delay = 1.5f;


    Animator eAnimator;
    private void Start()
    {
        eAnimator = GetComponentInParent<Animator>();
        follow = GetComponentInChildren<EnemyFollow>().gameObject;
    }
    private void Update()
    {
        myTr = GetComponent<Transform>();
        myX = myTr.position.x;
        time += Time.deltaTime;
        //Debug.Log(myX - playerX);
        if(GetComponent<Enemy>().life == false)
        {
            GetComponent<Enemy>().spd = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            playerTr = collision.GetComponent<Transform>();
            playerX = playerTr.position.x;
            if(myX - playerX < 0)
            {
                totalX = (myX - playerX) * -1;
            }
            else
            {
                totalX = myX - playerX;
            }

            if (totalX < 6)
            {
                Fire();
            }
            Stop();
        }
    }

    public void Stop()
    {
        if (myX - playerX <= 4 && myX - playerX >= -4 && GetComponent<Enemy>().life != false)
        {
            GetComponent<Enemy>().spd = 0f;
        }
        else
            GetComponent<Enemy>().spd = 2f;
    }

    public void Fire()
    {
        if (time >= delay && GetComponent<Enemy>().life != false)
        {
            eAnimator.SetTrigger("Attack");
            mid = (myX - playerX) * 0.5f;
            GameObject ball = Instantiate(fireBall);
            ball.transform.position = firePos.transform.position;
            look = (myTr.position.x - firePos.transform.position.x) * -1;

            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            rb.AddForce(ball.transform.right * look * power + ball.transform.up * 5, ForceMode2D.Impulse);
            time = 0;
        }
    }
}
