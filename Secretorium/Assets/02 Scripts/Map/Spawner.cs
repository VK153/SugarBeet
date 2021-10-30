using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mob,spawner,spawnPoint;//몬스터와 스포너, 지점 지정
    Transform sPoint;//스폰지점
    public float spawnDelay = 10, spawnTime = 0; //스폰 딜레이, 스폰후 경과시간
    public bool spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = false;

        sPoint = spawnPoint.GetComponent<Transform>();
        
    }

    void Update()
    {
        if (spawn)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime >= spawnDelay)
            {
                Instantiate(mob, sPoint);
                spawnTime = 0f;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
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
