using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHp=100;
    public float hp;
    public float avoidPoint = 30;
    public float dmg;
    float hpUp = 1.01f;
    public float shield = 0;
    public bool sugarBeat = false;
    float shieldHeal = 1;

    public float selfHeal = 0;
    float healTime = 2;

    public float toxDelay = 0.5f; //독장판 관련
    public float toxTime = 0f;
    public float toxDamage, toxDamageP = 1;

    AudioSource pSound;
    public AudioClip levelUp, hitSound, overSound, avSound;

    public Image hpBar;
    public Text hpText;

    public Image expBar;
    public Text expText;

    public Text levelText;

    public Slider playing;

    GameObject startPos, endPos,player;

    public GameObject hudDamageText;
    public Transform hudPos;
    string miss = "Miss";
    public GameObject canvas;


    int level = 1;
    public float exp = 0;
    float maxExp = 10;
    float expUp = 1.1f;

    bool isKnockBack = false;
    float spd = 5;

    Rigidbody rb;
    Vector2 pos;

    public Text statText;
    public Text scrapText;
    float upCri;
    float critical;
    public GameObject stat;
    bool statOn = false;
    public bool autoFire = false;
    public float aF = 0;
    public float aFCoolTime;

    public int scrap;
    public int key;
    // Start is called before the first frame update
    void Start()
    {
        startPos = GameObject.Find("StartPos");
        endPos = GameObject.Find("EndPos");
        player = GameObject.Find("Player");
        hp = maxHp;
        playing.minValue = startPos.transform.position.x;
        playing.maxValue = endPos.transform.position.x;
        pSound = GetComponent<AudioSource>();
        //pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(aFCoolTime);
        AutoFire();

        StatText();
        scrapText.text = "스크랩 : " + scrap + "\n열쇠 : " + key;

        playing.value = player.transform.position.x;

        hpBar.fillAmount = hp / maxHp;
        hpText.text = ((int)hp + " / " + (int)maxHp);
        expBar.fillAmount = exp / maxExp;
        expText.text = ((int)exp + " / " + (int)maxExp);
        levelText.text = ("LV. " + level);



        if (exp >= maxExp)
        {
            LevelUp();
            //Debug.Log("레벨업!");
            //레벨업이 정상작동하는지 확인하기 위한 용도입니다(정상작동중)
        }
        if(sugarBeat == true)
        {
            shieldHeal -= Time.deltaTime;
            if(shieldHeal <= 0)
            {
                shield += 10;
                shieldHeal = 1;
            }
            if(shield >= 20000)
            {
                shield = 20000;
            }
        }
        healTime -= Time.deltaTime;
        if(healTime <= 0)
        {
            hp += selfHeal;
            healTime = 2;
        }
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (statOn == false)
            {
                for (int i = 0; i < 2; i++)
                {
                    stat.transform.GetChild(i).gameObject.SetActive(true);
                    statOn = true;
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    stat.transform.GetChild(i).gameObject.SetActive(false);
                    statOn = false;
                }
            }
        }
    }

    

    public void TakeAttack(float dmg)
    {
        int a = Random.Range(0, 100);
        if (shield > 0)
        {
            if (a > avoidPoint)
            {
                shield -= dmg;

                pSound.clip = hitSound;
                pSound.Play();

                GameObject hudText = Instantiate(hudDamageText, canvas.transform); // 생성할 텍스트 오브젝트
                hudText.transform.position = hudPos.position; // 표시될 위치
                hudText.GetComponent<DamageText>().damage = (int)dmg; // 데미지 전달
                                                                      //Debug.Log("아야!");
                                                                      //Enemy와 충돌 할 경우 Enemy로부터 dmg값을 받아와 데미지받는것을 처리하는곳입니다
                                                                      //정상작동 확인을 위해 avoidPoint값을 30으로 주었습니다 (30%)
            }
            else
            {

                pSound.clip = avSound;
                pSound.Play();

                GameObject hudText = Instantiate(hudDamageText, canvas.transform); // 생성할 텍스트 오브젝트
                hudText.transform.position = hudPos.position; // 표시될 위치
                hudText.GetComponent<DamageText>().damage = 0; // 데미지 전달
                                                               //Debug.Log("히히 빚나감");
                                                               //충돌을 하였음에도 일정 확률로 회피 - 데미지를 받지 않습니다.
            }
        }
        else
        {
            if (a > avoidPoint)
            {
                hp -= dmg;

                pSound.clip = hitSound;
                pSound.Play();

                GameObject hudText = Instantiate(hudDamageText, canvas.transform); // 생성할 텍스트 오브젝트
                hudText.transform.position = hudPos.position; // 표시될 위치
                hudText.GetComponent<DamageText>().damage = (int)dmg; // 데미지 전달
                                                                      //Debug.Log("아야!");
                                                                      //Enemy와 충돌 할 경우 Enemy로부터 dmg값을 받아와 데미지받는것을 처리하는곳입니다
                                                                      //정상작동 확인을 위해 avoidPoint값을 30으로 주었습니다 (30%)
            }
            else
            {

                pSound.clip = avSound;
                pSound.Play();

                GameObject hudText = Instantiate(hudDamageText, canvas.transform); // 생성할 텍스트 오브젝트
                hudText.transform.position = hudPos.position; // 표시될 위치
                hudText.GetComponent<DamageText>().damage = 0; // 데미지 전달
                                                               //Debug.Log("히히 빚나감");
                                                               //충돌을 하였음에도 일정 확률로 회피 - 데미지를 받지 않습니다.
            }
        }
        if (hp <= 0)
        {
            Die();
        }
    }
    
    public void LevelUp()
    {
        level += 1;
        pSound.clip = levelUp;
        pSound.Play();
        maxHp = maxHp * hpUp;
        exp = exp - maxExp;
        maxExp = maxExp * expUp;
        hp = maxHp;
        //레벨업시 처리할 함수입니다. 최대 체력이 1%만큼 증가하며 경험치 요구량이 10%씩 증가합니다.
    }
    public void Kill(float exps)
    {
        exp += exps;
        //적이 디스트로이 될 경우 호출합니다
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            KnouckBack(other.transform.position);
        }
        //적을 죽일 시 경험치함수들이 정상작동하는지 보기위해 임시로 만든 간단한 충돌트리거입니다
    }*/
    public void KnouckBack(Vector2 pos,float spd)
    {
        float x = transform.position.x - pos.x;
        if (x < 0)
        {
            x = 1;
        }
        else
        {
            x = -1;
        }
        StartCoroutine(KnouckBackZ(x,spd));
    }
    
    public void Die()
    {
        GameManager.gm.GameOver();

        pSound.clip = overSound;
        pSound.Play();
    }
    IEnumerator KnouckBackZ(float dir,float spd)
    {
        isKnockBack = true;
        float ctime = 0;
        while (ctime < 0.2f)
        {
            //if (transform.rotation.y == 0)
            //{
                transform.Translate(Vector2.left * spd * Time.deltaTime * dir);
            //}
            //else
            //{
            //    transform.Translate(Vector2.right * spd * Time.deltaTime *-1f* dir);
            //}
            ctime += Time.deltaTime;
            yield return null;
        }
        isKnockBack = false;
    }

    public void StatText()
    {
        dmg = GetComponentInChildren<WeaponFire>().dmg;
        upCri = GetComponentInChildren<WeaponFire>().upCri;
        critical = GetComponentInChildren<WeaponFire>().critical;
        statText.text = "데미지 : " + dmg + "\n회피율 : " + avoidPoint + "\n치명타피해량 : " + upCri + "\n치명타적중률 : "
            + critical + "\n이동속도 : " + GetComponent<PlayerMovement>().speed + "\n회복력 : " + selfHeal;
    }

    public void AutoFire()
    {
        if (aF >0)
        {
            if(autoFire == false)
            {
                autoFire = true;
            }
            aF -= Time.deltaTime;
            if(aF <= 0)
            {
                autoFire = false;
                aF = 0;
                return;
            }
        }
        if(aFCoolTime > 0)
        {
            aFCoolTime -= Time.deltaTime;
            if (aFCoolTime <= 0)
            {
                GetComponent<ActionController>().TiketCoolTime = false;
                aFCoolTime = 0;
                return;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Tox"))//독장판 데미지
        {
            toxTime += Time.deltaTime;
            if(toxTime > toxDelay)
            {
                toxTime = 0;
                pSound.clip = hitSound;
                pSound.Play();

                hp -= toxDamage = maxHp / 100 * toxDamageP;
                GameObject hudText = Instantiate(hudDamageText, canvas.transform);
                hudText.transform.position = hudPos.position;
                hudText.GetComponent<DamageText>().damage = (int)toxDamage;
            }
        }
    }

}
