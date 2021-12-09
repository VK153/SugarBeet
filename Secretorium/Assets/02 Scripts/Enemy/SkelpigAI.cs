using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class SkelpigAI : MonoBehaviour
{
    float range, total, high, Hto;
    float maxRange = 5f;
    float myX, plaX;
    float myY, plaY;
    float waitTime, delayTime = 1.5f, stop = 1.9f;
    float holdTime;
    public GameObject ef;
    public GameObject box;

    private void Start()
    {
        box.SetActive(false);
    }
    private void Update()
    {
        myX = ef.GetComponent<EnemyFollow>().enemyX;
        myY = ef.GetComponent<EnemyFollow>().enemyY;
        plaX = ef.GetComponent<EnemyFollow>().playerX;
        plaY = ef.GetComponent<EnemyFollow>().playerY;

        range = myX - plaX;
        high = myY - plaY;
        if (range < 0)
            total = range * -1;
        else
            total = range;
        if (high < 0)
            Hto = high * -1;
        else
            Hto = high;

        if (total <= maxRange && GetComponentInParent<Enemy>().FInd == true && Hto <=3&&GetComponentInParent<Enemy>().life !=false)
        {
            waitTime += Time.deltaTime;
            holdTime += Time.deltaTime;
            if(holdTime <=1)
            GetComponentInParent<Enemy>().spd = 0;
            Run();
        }
        else
        {
            GetComponentInParent<Enemy>().spd = 1.8f;
            waitTime = 0;
            holdTime = 0;
        }
        if( GetComponentInParent<Enemy>().life == false)
        {
            GetComponentInParent<Enemy>().spd = 0;
        }
    }

    public void Run()
    {
        if (waitTime >= delayTime)
        {
            GetComponentInParent<Enemy>().spd = 10;
            box.SetActive(true);
        }
        if (waitTime >= stop)
        {
            GetComponentInParent<Enemy>().spd = -1f;
            waitTime = 0f;
            box.SetActive(false);
        }
    }
}
