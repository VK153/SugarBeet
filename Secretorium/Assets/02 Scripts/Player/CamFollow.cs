using System.Collections;                   //작업자 : 김영호
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;

    public float dist = 15f, height = 2f, oriHeight, lowHeight, lowAmount = 3f, lowTime = 2, camSpeed = 2f;
    private float kDTimer = 0;
    public bool KDReset = false;
    Player player;
    Transform myTr;
    Vector3 follow;
    // Start is called before the first frame update
    void Start()
    {
        oriHeight = height;
        lowHeight = oriHeight - lowAmount;
        myTr = GetComponent<Transform>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.isGameover == false)
        {
            float h = Input.GetAxis("Horizontal");
            float ph = h * 4;
            Vector3 targetPos = new Vector3(target.transform.position.x + ph, target.transform.position.y + height, -dist);
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * camSpeed);

            if (Input.GetButton("Down"))
            {
                kDTimer += Time.deltaTime;
                if (kDTimer > lowTime)
                {
                    height = lowHeight;
                }
                KDReset = true;
            }
            else if (Input.GetButton("Up"))
            {
                kDTimer += Time.deltaTime;
                if (kDTimer > lowTime)
                {
                    height = oriHeight * 3f;
                }
                KDReset = true;
            }
            else if (KDReset)
            {
                height = oriHeight;
                kDTimer = 0;
                KDReset = false;
            }
        }
    }
}
