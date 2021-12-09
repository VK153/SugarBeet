using System.Collections;               //작업자 : 정재엽,김영호
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    GameObject gameManager;
    GameManager gm;
    public float dmg = 5, hp = 10, exp = 10;
    public float maxHp;
    Player ps;
    GameObject holster;
    WeaponFire weaponFire;
    public Image hpBar;
    public GameObject canvas;
    public bool life = true;

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
    public bool inBox, KBP = false;//플레이어 주변에 있는지 확인,플레이어가 죽였는지 (거짓이 기본)

    public int right = 0;



    public Animator eAnimator;//애니메이터
    Rigidbody2D eRigid;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gm = gameManager.GetComponent<GameManager>();
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
        Jump();
        DownJump();

        if (!inBox && lifeTime <= setLifeTime)
        {
            lifeTime += Time.deltaTime;
        }
        else if(lifeTime > setLifeTime)
        {
            gm.mobCount--;
            Destroy(this.gameObject);
        }
        if (gm.isGameOver) spd = 0f;
        if (gm.isGameClear) Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet") && shild == false && life !=false)
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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("MobAble"))
        {
            inBox = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MobAble"))
        {
            inBox = false;
        }
    }
    //플레이어와 충돌 할 경우 플레이어 스크립트의 TakeAttack을 가져와 플레이어에게 데미지를 줍니다
    public void TakeDamage(float damage)
    {
        hp -= damage;

        GameObject hudText = Instantiate(hudDamageText,canvas.transform); // 생성할 텍스트 오브젝트
        hudText.transform.position = hudPos.position; // 표시될 위치
        hudText.GetComponent<DamageText>().damage = (int)damage; // 데미지 전달

        if (hp <= 0 && life != false)
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
            else
            {
                ps.scrap += 1;
            }
            life = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Kill(exp);
            KBP = true;
            spd = 0;
            gm.mobCount--;
            this.GetComponent<Animator>().SetTrigger("Die");
            Destroy(gameObject, 1f);
        }
    }
    //플레이어에게 데미지를 받을 시 호출할 함수입니다. 만약 죽을경우 플레이어의 Kill함수를 호출해 경험치를 제공합니다
    int dir = -1;
    public void Follow()
    {
        if (GetComponentInChildren<EnemyFollow>().dir <= 0)   //조건이 맞을경우 오른쪽으로 가야함
        {
            dir = GetComponentInChildren<EnemyFollow>().dir;
            Erb.velocity = new Vector2(spd, Erb.velocity.y);
            enemyTr.rotation = Quaternion.Euler(0, 180, 0);
            right = 1;
        }
        else
        {
            dir = GetComponentInChildren<EnemyFollow>().dir;
            Erb.velocity = new Vector2(-spd, Erb.velocity.y);
            enemyTr.rotation = Quaternion.Euler(0, 0, 0);
            right = 0;
        }
    }
    public void GoHome()
    {
        if (GetComponentInChildren<EnemyFollow>().dir < 0)
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
            }
            
        }
    }
}
