using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holster : MonoBehaviour
{
    public float invisibleTime = 0;
    Player pl;

    private void Start()
    {
        pl = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invisibleTime > 0)
        {
            gameObject.tag = "Untagged";
            pl.plimage.color = new Color(1, 1, 1, 0.3f);
            invisibleTime -= Time.deltaTime;
        }
        else if(invisibleTime <= 0)
        {
            gameObject.tag = "PlayerHit";
            pl.plimage.color = new Color(1, 1, 1, 1);
            invisibleTime = 0;
        }
    }
}
