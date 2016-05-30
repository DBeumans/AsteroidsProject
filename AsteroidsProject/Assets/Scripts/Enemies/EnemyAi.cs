using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

    [SerializeField]
    float MovementSpeed = 2;
    [SerializeField]
    Transform GroundedCheck;

    [SerializeField]
    Transform FieldOfViewFront;
    [SerializeField]
    Transform FieldOfViewBack;

    [SerializeField]
    bool PlayerInSight;

    bool PlayerIsBehind;
    [SerializeField]

    bool grounded;

    bool Left;
    bool Right = true;

    bool FieldOfViewFrontBool;
    bool FieldOfViewBackBool;

    bool isFacingLeft;
    bool isFacingRight;

    void Update()
    {
        CheckPlayer();
    }
    void FixedUpdate()
    {
        raycasting();
        EnemyTransform();
    }
    void raycasting()
    {
        Debug.DrawLine(this.transform.position, GroundedCheck.position, Color.green); // Check ground
        Debug.DrawLine(this.transform.position, FieldOfViewFront.position, Color.red); 
        Debug.DrawLine(this.transform.position, FieldOfViewBack.position, Color.blue); 

        grounded = Physics2D.Linecast(this.transform.position, GroundedCheck.position, 1 << LayerMask.NameToLayer("Ground")); // Check ground
        FieldOfViewFrontBool = Physics2D.Linecast(this.transform.position, FieldOfViewFront.position, 1 << LayerMask.NameToLayer("Player"));
        FieldOfViewBackBool = Physics2D.Linecast(this.transform.position, FieldOfViewBack.position, 1 << LayerMask.NameToLayer("Player"));
    }

    void EnemyTransform()
    {

        if(grounded)
        {
            if(Right)
            {  
                transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
                isFacingRight = true;
                isFacingLeft = false;

            }
            if(Left)
            {
                
                transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
                isFacingLeft = true;
                isFacingRight = false;
                
            }
            
        }
        
    }

    void CheckPlayer()
    {
        if(FieldOfViewFrontBool)
        {
            ChasePlayer(true);
            Debug.Log("Chasing The Player!");
        }
        if (FieldOfViewBackBool)
        {
            ChasePlayer(false);
            Debug.Log("Enemy Flipped!");
        }
        
        if (FieldOfViewFrontBool == false && FieldOfViewBackBool == false)
        {
            Debug.Log("Nothing! Both Are False!");
        }

    }

    void FlipEnemy()
    {
        if(isFacingLeft)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(isFacingRight)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void ChasePlayer(bool value)
    {
        if(value) // Rechts
        {
            Right = false;
            Left = false;
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(!value) // Links
        {
            Right = false;
            Left = false;
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("GoLeft"))
        {
            Left = true;
            Right = false;
            Debug.Log("Going Left");
        }
        if(other.gameObject.CompareTag("GoRight"))
        {
            Right = true;
            Left = false;
            Debug.Log("Going Right");
        }
        if (other.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(10, 10);
        }

    }
}
