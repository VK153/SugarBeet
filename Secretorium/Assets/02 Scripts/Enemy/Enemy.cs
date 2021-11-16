using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    // Warning!!!!!!!!!!!! 이 스크립트는 플레이어 스크립트의 정상작동을 확인하는 용도의 임시 스크립트입니다!!!!  Warning!!!!!!!!!!!!
    // Warning!!!!!!!!!!!! 이 스크립트는 플레이어 스크립트의 정상작동을 확인하는 용도의 임시 스크립트입니다!!!!  Warning!!!!!!!!!!!!
    // Warning!!!!!!!!!!!! 이 스크립트는 플레이어 스크립트의 정상작동을 확인하는 용도의 임시 스크립트입니다!!!!  Warning!!!!!!!!!!!!
    // Warning!!!!!!!!!!!! 이 스크립트는 플레이어 스크립트의 정상작동을 확인하는 용도의 임시 스크립트입니다!!!!  Warning!!!!!!!!!!!!



    public float dmg = 5, hp = 10, exp = 10;
    public float maxHp;
    Player ps;
    GameObject holster;
    WeaponFire weaponFire;
    public Image hpBar;
    public GameObject canvas;

    GameObject player;
    Player atk;

    public GameObject hudDamageText;
    public Transform hudPos;

    Transform enemyTr;
    Transform lastX;
    Transform tileTr;
    float tileX, tileY;
    public float lax;
    public Transform playerTr;
    public float spd = 1;
    public bool FInd = false;
    public bool pat = true;
    float enemyX, enemyY;
    float totalX, totalY;
    int playerX;
    public bool fx = true;

    public bool shild = false;
    public bool canJump = false, isHigh = false,isJump = false;
    public bool goDown = true, isLow = false;

    private Rigidbody2D Erb;
    float jumpForce = 13f;
    GameObject ba;
    BoxCollider2D box;

    float downTime = 2, alfa;


    public float lifeTime = 0f, setLifeTime = 15f;//생명유지시간과 경과시간
    public bool inBox;//플레이어 주변에 있는지 확인



    public Animator eAnimator;//애니메이터
    Rigidbody2D eRigid;


    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.Find("Player").GetComponent<Player>();
        ba = GetComponentInChildren<EnemyBase>().gameObject;
        box = ba.GetComponent<BoxCollider2D>();
        maxHp = hp;
        holster = GameObject.Find("Holster");
        weaponFire = holster.GetComponentInChildren<WeaponFire>();
        canvas = transform.GetChild(0).gameObject;

        player = GameObject.Find("Player");
        atk = player.GetComponent<Player>();


        eAnimator = gameObject.GetComponent<Animator>();
        eRigid = gameObject.GetComponent<Rigidbody2D>();

        lastX = GetComponent<Transform>();
        lax = lastX.position.x;
        GetComponentInChildren<EnemyFollow>().lastX = lax;
        Erb = GetComponent<Rigidbody2D>();
        if(transform.localScale.x == 0.8f)
        {
            jumpForce = 13;
        }
        else if(transform.localScale.x == 0.35f)
        {
            jumpForce = 13;
        }
        else
        {
            jumpForce = 13;
        }
        inBox = false;//플레이어 주변 범위내 없음으로 시작
    }

    // Update is called once per frame
    void Update()
    {
        if (eRigid.velocity.x != 0)
        {
            eAnimator.SetBool("Run", true);
            eAnimator.SetBool("Idle", false);
        }
        else
        {
            eAnimator.SetBool("Run", false);
            eAnimator.SetBool("Idle", true);
        }

        hpBar.fillAmount = hp / maxHp;
        enemyTr = GetComponent<Transform>();
        enemyX = enemyTr.position.x;
        enemyY = enemyTr.position.y;
        if (FInd == true)
        {
            Follow();
        }
        else if (FInd == false)
        {
            if(lax != enemyTr.position.x)
            GoHome();
        }
        //Debug.Log(spd);
        Jump();
        DownJump();
        //Debug.Log(canJump);

        if (!inBox && lifeTime <= setLifeTime)
        {
            lifeTime += Time.deltaTime;
        }
        else if(lifeTime > setLifeTime)
        {
            GameManager.gm.mobCount--;
            Debug.Log("lifeTimeOut");
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.CompareTag("PlayerHit") && GetComponentInChildren<EnemyFollow>().atk == true)
        //{
        //    atk.TakeAttack(dmg);
        //}
        if (other.CompareTag("Bullet") && shild == false)
        {
            weaponFire.Dmg();
            TakeDamage(weaponFire.dmg);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("MobAble"))//플레이어 주변에 있을경우 생명시간 초기화
        {
            lifeTime = 0f;
            inBox = true;
        }
        //if (other.CompareTag("EJumpTile"))
        //{
        //    tileTr = other.GetComponent<Transform>();
        //    tileX = tileTr.position.x;
        //    tileY = tileTr.position.y;
        //    if(enemyX - tileX < 0)
        //    {
        //        totalX = (enemyX - tileX) * -1;
        //    }
        //    else
        //    {
        //        totalX = enemyX - tileX;
        //    }
        //    if(enemyY - tileY < 0)
        //    {
        //        totalY = (enemyY - tileY) * -1;
        //    }
        //    else
        //    {
        //        totalY = enemyY - tileY;
        //    }
        //    if (totalX < 5 && totalY < 5)
        //    {
        //        canJump = true;
        //    }
        //    else
        //    {
        //        canJump = false;
        //    }
        //    //Debug.Log(canJump);
        //}
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("EJumpTile"))
        {
            //몹이 점프타일의 근처에 다가왔음을 알수있게 해주는 조건문
            tileTr = collision.GetComponent<Transform>();
            tileX = tileTr.position.x;
            tileY = tileTr.position.y;
            if (enemyX - tileX < 0)
            {
                totalX = (enemyX - tileX) * -1;
            }
            else
            {
                totalX = enemyX - tileX;
            }
            if (enemyY - tileY < 0)
            {
                totalY = (enemyY - tileY) * -1;
            }
            else
            {
                totalY = enemyY - tileY;
            }
            if (totalX < 2 && totalY < 5)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
            //Debug.Log(canJump);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MobAble"))
        {
            inBox = false;
        }
    }
    /*플레이어와 충돌 할 경우 플레이어 스크립트의 TakeAttack을 가져와 플레이어에게 데미지를 줍니다*/
    public void TakeDamage(float damage)
    {
        hp -= damage;

        GameObject hudText = Instantiate(hudDamageText,canvas.transform); // 생성할 텍스트 오브젝트
        hudText.transform.position = hudPos.position; // 표시될 위치
        hudText.GetComponent<DamageText>().damage = (int)damage; // 데미지 전달
        //base.TakeDamage(damage);

        if (hp <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Kill(exp);
            GameManager.gm.mobCount--;
            Destroy(gameObject);
        }
    }
    //플레이어에게 데미지를 받을 시 호출할 함수입니다. 만약 죽을경우 플레이어의 Kill함수를 호출해 경험치를 제공합니다 임시로50의 겸치량을 넣었습니다
    int dir = -1;
    public void Follow()
    {
        if (GetComponentInChildren<EnemyFollow>().dir <= 0)   //조건이 맞을경우 오른쪽으로 가야함
        {
            dir = GetComponentInChildren<EnemyFollow>().dir;
            //enemyTr.Translate(Vector2.right * spd * Time.deltaTime * dir);
            //Erb.AddForce(new Vector2(spd, 0), ForceMode2D.Impulse);
            Erb.velocity = new Vector2(spd, Erb.velocity.y);
            enemyTr.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            dir = GetComponentInChildren<EnemyFollow>().dir;
            //enemyTr.Translate(Vector2.left * spd * Time.deltaTime * dir);
            //Erb.AddForce(new Vector2(-spd, 0), ForceMode2D.Impulse);
            Erb.velocity = new Vector2(-spd, Erb.velocity.y);
            enemyTr.rotation = Quaternion.Euler(0, 0, 0);
            //Debug.Log(spd);
        }
    }
    public void GoHome()
    {
        //Debug.Log("집가자");
        if (GetComponentInChildren<EnemyFollow>().dir < 0)   //조건이 맞을경우 오른쪽으로 가야함
        {
            dir = GetComponentInChildren<EnemyFollow>().dir;
            enemyTr.Translate(Vector2.right * spd * Time.deltaTime * dir);
            enemyTr.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            dir = GetComponentInChildren<EnemyFollow>().dir;
            enemyTr.Translate(Vector2.left * spd * Time.deltaTime * dir);
            enemyTr.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void Jump()
    {
        if (canJump == true && isHigh == true && isJump == false)
        {
            Erb.AddForce(new Vector2(0, jumpForce - Erb.velocity.y), ForceMode2D.Impulse);
            //isJump = true;
        }
    }
    public void DownJump()
    {
        if(isLow == true)
        {
            downTime -= Time.deltaTime;
            if(downTime <= 0)
            {
                alfa = Random.Range(0, 99);
                if(alfa <= 30)
                {
                    box.isTrigger = true;
                    downTime = 2;
                }
                else
                {
                    downTime = 2;
                }
                //Debug.Log(box.isTrigger);
            }
            
        }
        //else if(isLow == false)
        //{
        //    downTime = 0;
        //}
        //Debug.Log(isLow);
    }

    private void OnDestroy()
    {
        if(inBox)
        {
            int i = Random.Range(0, 99);

            if (i < 11)
            {
                ps.scrap += 3;
            }
            else if (11 <= i && i < 36)
            {
                ps.scrap += 2;
            }
            else if (36 <= i && i < 71)
            {
                ps.scrap += 1;
            }
            else
            {
                ps.key += 1;
            }
        }
    }
}
