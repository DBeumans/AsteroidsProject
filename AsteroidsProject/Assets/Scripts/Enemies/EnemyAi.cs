﻿using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

    // FLOATS
    
    public float MovementSpeed = 2;
    float RandomNumber;

    float SendScore = 2;

    [SerializeField]
    float thrust = 100;
    // TRANSFORMS
    [SerializeField]
    Transform GroundedCheck;
    // BOOLEANS
    [SerializeField]
    bool PlayerInSight;
    bool PlayerIsBehind;

    [SerializeField]
    bool grounded;
    public bool Left;
    public bool Right = true;
    public bool isFacingLeft;
    public bool isFacingRight;
    public bool ChasePlayer;

    public bool isWalking;
    public bool isAttacking;

    ScoreHandler _ScoreHandler;
    Animator _anim;
    Rigidbody2D rb2d;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _ScoreHandler = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<ScoreHandler>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void AnimCheck()
    {
        if(isWalking)
        {
            _anim.SetBool("isWalking", true);
        }
        if(isAttacking)
        {
            _anim.SetBool("isAttacking", true);
        }
    }
    void Update()
    {
        AnimCheck();
        if (!grounded)
        {
            rb2d.gravityScale = 20;
        }
        if(grounded)
        {
            rb2d.gravityScale = 1;
        }
        chase();


    }
    void FixedUpdate()
    {
        raycasting();
        EnemyTransform();
    }
    void raycasting()
    {
        Debug.DrawLine(this.transform.position, GroundedCheck.position, Color.green); // Check ground

        if (this.gameObject.layer == LayerMask.NameToLayer("Enemy1"))
        {
            grounded = Physics2D.Linecast(this.transform.position, GroundedCheck.position, 1 << LayerMask.NameToLayer("Ground1")); // Check ground
        }

        if (this.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            grounded = Physics2D.Linecast(this.transform.position, GroundedCheck.position, 1 << LayerMask.NameToLayer("Ground")); // Check ground
        }
        
    }

    public void chase()
    {
        if (ChasePlayer)
        {
            MovementSpeed = 0;
        }
        if(!ChasePlayer)
        {
            MovementSpeed = 2;
        }

    }

    public void EnemyTransform()
    {

        if (grounded)
        {
            if (Right)
            {
                transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
                isFacingRight = true;
                isFacingLeft = false;

            }
            if (Left)
            {

                transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
                isFacingLeft = true;
                isFacingRight = false;

            }

            if(isFacingLeft)
            {
                Left = true;
                Right = false;
            }
            if(isFacingRight)
            {
                Right = true;
                Left = false;
            }

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(10, 10);
        }

        if(other.gameObject.tag == "Bullet")
        {
            _ScoreHandler.RecieveScore(SendScore);
            MovementSpeed = 1;
            
            if(grounded)
            {
                
                rb2d.AddForce(Vector2.up * thrust);
                
            }
            
        }
        if(other.gameObject.tag != "Bullet")
        {
            MovementSpeed = 2;
        }

        

    }
}
