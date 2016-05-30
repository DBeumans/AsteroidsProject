using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

    [SerializeField]
    float MovementSpeed = 2;
    [SerializeField]
    Transform GroundedCheck;

    [SerializeField]
    bool PlayerInSight;
    [SerializeField]
    bool grounded;

    bool Left;
    bool Right = true;
    bool PlayerIsBehind;

    bool isFacingLeft;
    bool isFacingRight;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        raycasting();
        EnemyTransform();
    }
    void raycasting()
    {
        Debug.DrawLine(this.transform.position, GroundedCheck.position, Color.green); // Check ground

        grounded = Physics2D.Linecast(this.transform.position, GroundedCheck.position, 1 << LayerMask.NameToLayer("Ground")); // Check ground
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
