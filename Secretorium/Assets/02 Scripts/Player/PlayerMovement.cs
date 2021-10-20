﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Transform pPosition;
    public float speed = 5f, jumpCool = 1,  h, y, jTimer = 0;
    private Rigidbody2D pBody;
    BoxCollider2D box;
    WeaponFire weaponFire;

    AudioSource pSound;
    public AudioClip jumpSound, fallSound;


    Animator pAnimation;

    public float jumpForce = 50f;

    public int maxJump = 1, jumpCount = 0;
    public bool isJumping = false, isGround = false, isWall = false, downAble = false,fSound = true;

    // Start is called before the first frame update
    void Start()
    {
        pPosition = GetComponent<Transform>();
        pBody = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        weaponFire = GetComponentInParent<WeaponFire>();
        pAnimation = GetComponent<Animator>();
        pSound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (fSound)
        {
            pSound.clip = fallSound;
            pSound.Play();
            fSound = false;
        }
        jumpCount = 0;
        isJumping = false;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            //Debug.Log("Floor");
            isGround = true;
            downAble = false;            
        }
        else if (collision.collider.CompareTag("TFloor"))
        {

            //Debug.Log("tFloor");
            isGround = true;
            downAble = true;
        }
        else
        {
            pBody.velocity = new Vector2(0f, -10);
        }
        if (collision.collider.CompareTag("Wall"))
        {
            isWall = true;
            pBody.velocity = new Vector2(-h * speed, 0f);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Floor"))
        {
            isGround = false;
            box.isTrigger = false;

        }
        if (collision.collider.CompareTag("Wall"))
        {
            isWall = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("TFloor"))
        {
            box.isTrigger = false;
        }
    }
    float slowTime = 3f, slowDelay;
    public bool stun = false;
    void Update()
    {
        if (stun == false)
        {


            if (speed < 5)
            {
                slowDelay += Time.deltaTime;
                if (slowDelay >= slowTime)
                {
                    speed = 5;
                    slowDelay = 0;
                }
            }
            jTimer += Time.deltaTime;
            if (Input.GetButtonDown("Jump") && (jumpCount < maxJump) && !Input.GetButton("Down") && jTimer > jumpCool && isGround)//점프
            {
                print("Jump");
                isJumping = true;
                jumpCount++;
                pBody.AddForce(new Vector2(0, jumpForce - pBody.velocity.y), ForceMode2D.Impulse);
                pSound.clip = jumpSound;
                pSound.Play();
                jTimer = 0;
            }
            else if (Input.GetButtonDown("Jump") && Input.GetButton("Down") && isGround && downAble)//하향점프
            {
                print("DownJump");
                box.isTrigger = true;
                downAble = false;
                pSound.clip = jumpSound;
                pSound.Play();
            }
            if (h < 0)//캐릭터방향
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                pAnimation.SetBool("Run", true);
            }
            else if (h > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                pAnimation.SetBool("Run", true);
            }
            else
            {
                pAnimation.SetBool("Run", false);
            }
            //if (!isGround && !trigger)
            //{
            //    box.isTrigger = false;
            //    Debug.Log("X FJump");
            //}
        }

    }
    void FixedUpdate()
    {
        if(pBody.velocity.y < -5)
        {
            fSound = true;
        }
        if (stun == false)
        {


            h = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");
            pBody.velocity = new Vector2(h * speed, pBody.velocity.y);
            //if (!isJumping && isGround && pBody.velocity.y > 0)
            //{
            //    pBody.velocity = new Vector2(0f, -12f);
            //}
        }
    }

}