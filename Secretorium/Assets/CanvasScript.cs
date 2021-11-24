using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    Enemy monster;
    //Transform tr;
    RectTransform tr;
    // Start is called before the first frame update
    void Start()
    {
        monster = GetComponentInParent<Enemy>();
        tr = GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (monster.GetComponent<Enemy>().right == 0)
        {
            tr.rotation = Quaternion.Euler(0, 0, 0);
            //Debug.Log("왼쪽");
        }
        else if (monster.GetComponent<Enemy>().right == 1)
        {
            tr.rotation = Quaternion.Euler(0, -0.1f, 0);
            //Debug.Log("오른쪽");
        }
    }
}
