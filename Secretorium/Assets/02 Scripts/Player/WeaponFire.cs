using System.Collections;                   //작업자 : 김영호, 정재엽
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    public GameObject bulletFactory;
    public GameObject hg;
    public GameObject shootPos;
    public bool canSoot = false;
    public float bSpeed = 10;
    Player player;

    private float time = 0;
    public float delay = 0.2f;

    public float dmg;
    public float baseDmg = 5f;
    public float bonusDmg = 0;
    float criUp = 0;
    public float upCri = 0;

    GameObject holster;
    AudioSource wSound;
    public AudioClip fire;
    GameManager gm;

    public float critical = 0;
    float criCount;

    public bool gDmg = false;

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GetComponentInParent<Player>();
        wSound = GetComponent<AudioSource>();
        holster = GameObject.Find("Holster");
    }

    void Update()
    {
        if (!gm.pause && player.isGameover == false)
        {
            if (time <= delay)
            {
                time += Time.deltaTime;
            }
            if (Input.GetMouseButton(0) && time > delay)
            {
                time = 0f;
                Shoot();
            }
            if(Input.GetMouseButton(1) && canSoot == true)
            {
                HGSoot();
                canSoot = false;
            }
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = shootPos.transform.position;
        bullet.transform.rotation = holster.transform.rotation;
        wSound.clip = fire;
        wSound.Play();
    }

    private void HGSoot()
    {
        GameObject bomb = Instantiate(hg);
        bomb.transform.position = shootPos.transform.position;
        bomb.transform.rotation = holster.transform.rotation;
    }

    public void Dmg()
    {
        criCount = Random.Range(0, 100);
        if(criCount >= critical)
        {
            dmg = baseDmg + bonusDmg;
        }
        else
        {
            criUp = baseDmg * upCri;
            dmg = baseDmg * 2 + criUp + bonusDmg ;
        }
        if(gDmg == true)
        {
            dmg = baseDmg * 10;
            gDmg = false;
        }
    }
}
