using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class NamedMonkiAi : MonoBehaviour
{
    GameObject attackZone;
    GameObject player;
    Player atk;

    float enemyX, playerX;
    public bool blood = false;
    float bleedingTime = 4.1f, count;
    public int bloodCount;
    private void Start()
    {
        attackZone = GetComponentInChildren<NamedMonkiAttack>().gameObject;
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
            if (count >= 1)
            {
                count = 0;
                atk.hp -= atk.hp * 0.01f;
                bloodCount++;
            }
            if (bloodCount >= 4)
            {
                count = 0;
                bloodCount = 0;
                blood = false;
            }
        }
    }

    public void AttackZone()
    {
        if (enemyX - playerX <= 1.5f)
        {
            attackZone.SetActive(true);
        }
        else
            attackZone.SetActive(false);
    }
}
