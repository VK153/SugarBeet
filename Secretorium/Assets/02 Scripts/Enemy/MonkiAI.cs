using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkiAI : MonoBehaviour
{
    GameObject attackZone;
    GameObject player;
    Player atk;

    float enemyX, playerX;
    public bool blood = false;
    float bleedingTime = 4.1f, count;
    float delayTime = 0.3f;
    public int bloodCount;
    private void Start()
    {
        attackZone = GetComponentInChildren<EnemyAttack>().gameObject;
        player = GameObject.Find("Player");
        atk = player.GetComponent<Player>();
    }

    private void Update()
    {
        enemyX = GetComponent<EnemyFollow>().enemyX;
        playerX = GetComponent<EnemyFollow>().playerX;
        AttackZone();
        if (blood == true)
        {
            count += Time.deltaTime;
            if (count >=1)
            {
                count = 0;
                atk.hp -= atk.hp*0.01f;
                bloodCount++;
            }
            if (bloodCount >=4)
            {
                count = 0;
                bloodCount = 0;
                blood = false;
            }
        }
        //Debug.Log(blood);
    }

    public void AttackZone()
    {
        if (enemyX - playerX <= 1.5f)
        {
            delayTime -= Time.deltaTime;
            if (delayTime <= 0)
            {
                attackZone.SetActive(true);
                delayTime = 0.3f;
            }
            else
                attackZone.SetActive(false);
        }
        else
            attackZone.SetActive(false);
    }
}
