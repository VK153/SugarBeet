using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour
{
    public float invisibleTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(invisibleTime > 0)
        {
            gameObject.tag = "Untagged";
            invisibleTime -= Time.deltaTime;
        }
        else if(invisibleTime <= 0)
        {
            gameObject.tag = "PlayerHit";
            invisibleTime = 0;
        }
    }
}
