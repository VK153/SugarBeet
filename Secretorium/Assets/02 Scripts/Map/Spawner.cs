using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Spawner : MonoBehaviour
{
    public GameObject mob,spawner,spawnPoint,gmO;//몬스터와 스포너, 지점 지정
    Transform sPoint;//스폰지점
    public float spawnDelay = 10, spawnTime = 0; //스폰 딜레이, 스폰후 경과시간
    public bool spawn, sSwitch;
    public Sprite offSwitch,offSpawner;
    GameManager gm;
    AudioSource switchSound;

    // Start is called before the first frame update
    void Start()
    {
        spawn = false;
        sSwitch = true;
        sPoint = spawnPoint.GetComponent<Transform>();
        switchSound = GetComponent<AudioSource>();

    }
    private void Awake()
    {
        gm = gmO.GetComponent<GameManager>();
        gm.spawnerCount++;
    }

    public void Update()
    {
        if (spawn&&sSwitch&&gm.mobMaxCount > gm.mobCount)
        {
            spawnTime += Time.deltaTime;
            if (spawnTime >= spawnDelay)
            {
                Instantiate(mob, new Vector3(sPoint.position.x,sPoint.position.y,0), Quaternion.identity);
                spawnTime = 0f;
                gm.mobCount++;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerHit") && Input.GetKey(KeyCode.E) && sSwitch)
        {
            sSwitch = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = offSwitch;
            spawnPoint.GetComponent<SpriteRenderer>().sprite = offSpawner;
            gm.spawnerCount--;
            gm.mobMaxCount--;
            switchSound.Play();
            
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
