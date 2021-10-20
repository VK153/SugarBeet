using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOff : MonoBehaviour
{
    Button button;//옵션창 활성화시 메인버튼 비활성화
    void Start()
    {
        button = gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MainMenu.optionOn == true)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
