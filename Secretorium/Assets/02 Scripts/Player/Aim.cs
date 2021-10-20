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
            //Vector2 mPosition = Input.mousePosition;
            //Vector3 oPosition = transform.position;

            //Vector2 target = Camera.main.ScreenToWorldPoint(mPosition);

            //먼저 계산을 위해 마우스와 게임 오브젝트의 현재의 좌표를 임시로 저장합니다.
            Vector3 mPosition = Input.mousePosition; //마우스 좌표 저장
            Vector3 oPosition = transform.position; //게임 오브젝트 좌표 저장

            //카메라가 앞면에서 뒤로 보고 있기 때문에, 마우스 position의 z축 정보에
            //게임 오브젝트와 카메라와의 z축의 차이를 입력시켜줘야 합니다.
            mPosition.z = oPosition.z - Camera.main.transform.position.z;

            //화면의 픽셀별로 변화되는 마우스의 좌표를 유니티의 좌표로 변화해 줘야 합니다.
            //그래야, 위치를 찾아갈 수 있겠습니다.
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
