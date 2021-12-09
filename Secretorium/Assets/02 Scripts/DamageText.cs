using System.Collections;                   //작업자 : 김영호
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    private float moveSpeed;
    private float alphaSpeed;
    private float destroyTime;
    public TextMeshProUGUI ftext;
    Color alpha;
    public int damage;
    public float fSize, oriSize;
    Transform pSize;

    // Start is called before the first frame update
    void Start()
    {
        ftext = this.GetComponent<TextMeshProUGUI>();
        pSize = GetComponentInParent<Transform>();

        oriSize = ftext.fontSize;
        fSize = 1 - (pSize.lossyScale.x - 1f)/1.75f;
        //Debug.Log(pSize.lossyScale.x);
        moveSpeed = 2.0f;
        alphaSpeed = 2.0f;
        destroyTime = 2.0f;

        alpha = ftext.color;
        ftext.text = damage.ToString();
        ftext.fontSize = fSize * oriSize;
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0)); // 텍스트 위치

        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
        ftext.color = alpha;
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
