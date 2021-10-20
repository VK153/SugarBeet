using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 1.5f;
    public float currentTime = 0f;


    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
