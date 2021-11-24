using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mob,spawner,spawnPoint;//몬스터와 스포너, 지점 지정
    Transform sPoint;//스폰지점
    public float spawnDelay = 10, spawnTime = 0; //스폰 딜레이, 스폰후 경과시간
    public bool spawn, sSwitch;
    public Sprite offSwitch,offSpawner;

    // Start is called before the first frame update
    void Start()
    {
        spawn = false;
        sSwitch = true;

        sPoint = spawnPoint.GetComponent<Transform>();
        
    }

    void Update()
    {
        if (spawn&&sSwitch&&GameManager.gm.mobMaxCount > GameManager.gm.mobCount)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime >= spawnDelay)
            {
                Instantiate(mob, new Vector3(sPoint.position.x,sPoint.position.y,0), Quaternion.identity);
                spawnTime = 0f;
                GameManager.gm.mobCount++;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit") && Input.GetKeyDown(KeyCode.E))
        {
            sSwitch = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = offSwitch;
            spawnPoint.GetComponent<SpriteRenderer>().sprite = offSpawner;
        }
        if (collision.CompareTag("SpawnHitBox"))
        {
            spawn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnHitBox"))
        {
            spawn = false;
            spawnTime = 0f;
        }
    }
}
