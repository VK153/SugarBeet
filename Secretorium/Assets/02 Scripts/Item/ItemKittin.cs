using System.Collections;                   //작업자 : 정재엽
using System.Collections.Generic;
using UnityEngine;

public class ItemKittin : MonoBehaviour
{
    GameObject pl;

    private void Start()
    {
        pl = GameObject.Find("Player").gameObject;
    }

    private void OnDestroy()
    {
        if (pl.GetComponent<ActionController>().getItem == true)
            pl.GetComponent<Player>().avoid += pl.GetComponent<Player>().avoid * 0.2f;
        else if (pl.GetComponent<ActionController>().getItem == false)
            pl.GetComponent<Player>().scrap += 4;
    }
}
