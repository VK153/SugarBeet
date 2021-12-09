using System.Collections;                   //작업자 : 김영호,정재엽
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D bRigi;
    WeaponFire weaponFire;
    GameObject holster;
    Aim aim;
    float x, y;
    float ox, oy;
    GameObject targetPos;
    

    void Start()
    {
        bRigi = GetComponent<Rigidbody2D>();
        holster = GameObject.Find("Holster");

        weaponFire = holster.GetComponentInChildren<WeaponFire>();
        aim = holster.GetComponent<Aim>();
        x = aim.dx;
        y = aim.dy;
        Vector2 dir = new Vector2(x,y);
        dir = dir.normalized;
        bRigi.velocity = dir * weaponFire.bSpeed;

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GunFollow")&& holster.GetComponentInParent<Player>().autoFire == true)
        {
            gameObject.GetComponent<DestroyEffect>().currentTime = 0;
            targetPos = collision.GetComponent<Enemy>().gameObject;
            ox = targetPos.transform.position.x;
            oy = targetPos.transform.position.y; 
            Vector3 oPos = transform.position;
            x = ox - oPos.x;
            y = oy - oPos.y;
            Vector2 dir = new Vector2(x,y);
            dir = dir.normalized;
            bRigi.velocity = dir * weaponFire.bSpeed;
        }
    }


}
