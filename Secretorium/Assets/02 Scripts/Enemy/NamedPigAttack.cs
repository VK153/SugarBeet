using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class NamedPigAttack : MonoBehaviour
{
    GameObject player;
    Player atk;
    PlayerMovement pm;
    public float spd = 30f;

    public float dmg = 10;

    float per = 50, count,stunTime;
    bool stun = false;
    private void Start()
    {
        player = GameObject.Find("Player");
        atk = player.GetComponent<Player>();
        pm = player.GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            count = Random.Range(0, 100);
            atk.KnouckBack(transform.position, spd);
            atk.TakeAttack(dmg);
            if(per >= count)
            {
                pm.stun = true;
                stun = true;
                Debug.Log("스턴!");
            }
        }
    }

    private void Update()
    {
        if(stun == true)
        {
            stunTime += Time.deltaTime;

            if(stunTime >= 3)
            {
                pm.stun = false;
                stun = false;
                stunTime = 0;
            }
        }
    }
}
