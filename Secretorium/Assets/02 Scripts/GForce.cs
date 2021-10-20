using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GForce : MonoBehaviour
{
    private Rigidbody2D pBody;
    private float gForce = 1f;
    private void Start()
    {
        pBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {

        pBody.velocity = new Vector2(0, pBody.velocity.y - gForce);
    }
}
