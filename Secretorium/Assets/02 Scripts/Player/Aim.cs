using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    Transform now;
    public float dy,dx;
    GameManager gm;
    void Start()
    {

        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        now = GetComponent<Transform>();
    }


    void Update()
    {
        if (Time.timeScale != 0)
        {
            Vector3 mPosition = Input.mousePosition;
            Vector3 oPosition = transform.position;

            mPosition.z = oPosition.z - Camera.main.transform.position.z;
            
            Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);

            dy = target.y - oPosition.y;
            dx = target.x - oPosition.x;
            float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
            if (dx > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
            }
            else
            {
                transform.rotation = Quaternion.Euler(180f, 0f, -rotateDegree);
            }
        }
    }
}
