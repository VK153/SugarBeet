using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCam : MonoBehaviour
{
    Vector2 MousePosition ;
    public Camera Camera;
    private float Wh, Hh;
    // Start is called before the first frame update
    private void Start()
    {
        Camera = transform.GetComponent<Camera>();
        Wh = Screen.width/2;
        Hh = Screen.height/2;
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        MousePosition = Input.mousePosition;
        gameObject.transform.position = new Vector3 ((MousePosition.x - Wh)/1000f, (MousePosition.y - Hh)/1000f,-10f);
        //Debug.Log(MousePosition);
        
    }
}
