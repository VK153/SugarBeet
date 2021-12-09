using System.Collections;                   //작업자 : 김영호
using System.Collections.Generic;
using UnityEngine;

public class BulletPos : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oPos = transform.position;
        x = oPos.x - ox;
        y = oPos.y - oy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || holster.GetComponentInParent<Player>().autoFire == true)
        {
            targetPos = collision.GetComponent<Enemy>().gameObject;
            Debug.Log(targetPos);
            ox = targetPos.transform.position.x;
            oy = targetPos.transform.position.y;
        }
    }
}
