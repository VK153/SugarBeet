using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject [] Points;//First,Second
    public float floorSpeed = 2;
    private int x = 0;
    public float eTime = 5f, eDelay = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eTime += Time.deltaTime;
        if (eTime >= eDelay)
        {
            if (x == 0)
            {
                //Debug.Log("E0");
                
                x = 1;
                eTime = 0f;
            }
            else if (x == 1)
            {
                //Debug.Log("E1");
                x = 0;
                eTime = 0f;
            }
        }
        Transform TargetPos = Points[x].GetComponent<Transform>();
        Vector3 targetPos = new Vector3(TargetPos.transform.position.x, TargetPos.transform.position.y, TargetPos.transform.position.z);
        gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * floorSpeed);
    }
}
