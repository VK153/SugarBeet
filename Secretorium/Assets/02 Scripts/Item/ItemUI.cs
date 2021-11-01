using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public GameObject go;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            go.SetActive(true);
            //collision.GetComponent<ActionController>().eat = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            go.SetActive(false);
            //collision.GetComponent<ActionController>().eat = false;
        }
    }
}
