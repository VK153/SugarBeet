using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //public Transform Pos;
    private Rigidbody2D bRigi;
    WeaponFire weaponFire;
    GameObject holster;
    Aim aim;
    float x, y;
    float ox, oy;
    GameObject targetPos;
    

    // Start is called before the first frame update
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

    // Update is called once per frame
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
            //Debug.Log(oPos);
            Vector2 dir = new Vector2(x,y);
            dir = dir.normalized;
            bRigi.velocity = dir * weaponFire.bSpeed;
            //Debug.Log(ox); Debug.Log(oy);
        }
        //else if(collision.CompareTag("Wall") || collision.CompareTag("Floor") || collision.CompareTag("TFloor"))
        //{
        //    Debug.Log(collision);
        //    Destroy(gameObject);
        //}
    }


}
