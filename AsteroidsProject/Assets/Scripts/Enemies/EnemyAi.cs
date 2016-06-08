﻿using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

    // FLOATS
    [SerializeField]
    float MovementSpeed = 2;
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

    ScoreHandler _ScoreHandler;

    Rigidbody2D rb2d;

    void Start()
    {
        
        _ScoreHandler = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<ScoreHandler>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(!grounded)
        {
            rb2d.gravityScale = 20;
        }
        if(grounded)
        {
            rb2d.gravityScale = 1;
        }

        
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

    public void Flip(bool value)
    {
        if(value)
        {
            if (isFacingLeft)
            {
                transform.eulerAngles = new Vector2(0, 0);
                Right = false;
                Left = true;
                
            }
            if (isFacingRight)
            {
                transform.eulerAngles = new Vector2(0, 180);
                Left = false;
                Right = true;
                
            }
        }
        else
        {
            
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

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("GoLeft"))
        {
            Left = true;
            Right = false;
            //Debug.Log("Going Left");
        }
        if(other.gameObject.CompareTag("GoRight"))
        {
            Right = true;
            Left = false;
            //Debug.Log("Going Right");
        }
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
