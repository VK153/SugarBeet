using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHappyBomb : MonoBehaviour
{
    public GameObject hb;
    private Rigidbody2D bRigi;
    WeaponFire weaponFire;
    GameObject holster;
    Aim aim;
    float x, y;
    float ox, oy;
    GameObject targetPos;
    public float bSpeed = 5;


    // Start is called before the first frame update
    void Start()
    {
        bRigi = GetComponent<Rigidbody2D>();
        holster = GameObject.Find("Holster");

        weaponFire = holster.GetComponentInChildren<WeaponFire>();
        aim = holster.GetComponent<Aim>();
        x = aim.dx;
        y = aim.dy;
        Vector2 dir = new Vector2(x, y);
        dir = dir.normalized;
        bRigi.velocity = dir * bSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hb.SetActive(true);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("PlayerHit"))
    //    {
    //        collision.GetComponent<Player>().hp += collision.GetComponent<Player>().maxHp * 0.1f;
    //    }
    //    else if (collision.CompareTag("GunFollow"))
    //    {
    //        collision.GetComponent<Enemy>().hp += collision.GetComponent<Enemy>().maxHp * 0.1f;
    //    }
    //}
}
