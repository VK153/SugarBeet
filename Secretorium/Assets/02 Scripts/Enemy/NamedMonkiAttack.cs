using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamedMonkiAttack : MonoBehaviour
{
    GameObject player;
    Player atk;
    public float spd = 30f;

    public float dmg = 10;

    private void Start()
    {
        player = GameObject.Find("Player");
        atk = player.GetComponent<Player>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit"))
        {
            atk.KnouckBack(transform.position, spd);
            atk.TakeAttack(dmg);
            GetComponentInParent<NamedMonkiAi>().blood = true;
            GetComponentInParent<NamedMonkiAi>().bloodCount = 0;
        }
    }
}
