using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSugar : MonoBehaviour
{
    GameObject pm;

    private void Start()
    {
        pm = GameObject.Find("Player").gameObject;
    }
    private void OnDestroy()
    {
        if (pm.GetComponent<ActionController>().getItem == true)
            pm.GetComponent<PlayerMovement>().speed += 0.5f;
        else if(pm.GetComponent<ActionController>().getItem == false)
        {
            pm.GetComponent<Player>().scrap += 4;
        }
    }
}
