using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float MovementSpeed = 7;
    [SerializeField]
    float SlamSpeed = 15;
    /*
    [SerializeField]
    float turnSpeed;
    */
    [SerializeField]
    float jumpPower = 20f;

    PlayerMovement _player;
    PlayerShooting _playershooting;

    SpecialEnemyAI _enemy;
    [SerializeField]
    Transform Playertransform;
    [SerializeField]
    Transform TeleportTarget;

    [SerializeField]
    GameObject _camtar;

    [SerializeField]
    bool grounded = false;

    [SerializeField]
    Transform groundedEnd;

    Rigidbody2D rb2d;

    bool canDoubleJump = false;

    bool _takeover = false;
    // Update is called once per frame
    void Start()
    {
        // Get component function.
        GetComponent();

        _camtar.SetActive(true);
        _player.enabled = true;
    }

    void GetComponent()
    {
        _playershooting = GetComponent<PlayerShooting>();
        _player = GetComponent<PlayerMovement>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        //_enemy = GameObject.FindGameObjectWithTag("SpecialEnemy").GetComponent<SpecialEnemyAI>();
    }
    void FixedUpdate ()
    {
        Inputs();
         
	}

    void Update()
    {
        raycasting();
    }
    void Inputs()
    {
        // MOVEMENT
        // LEFT
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        //RIGHT
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * MovementSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        // Slam 
        if(Input.GetKey(KeyCode.S) && grounded == false)
        {
            transform.Translate(Vector2.down * SlamSpeed * Time.deltaTime);
        }
        
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Playertransform.transform.position += transform.position = new Vector3(0, 0,12f);

        }
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            Playertransform.transform.position += transform.position = new Vector3(0, 0, -12f);

        }

        // JUMP && DOUBLE JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {         
            if(grounded)
            {
                
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower * 2);
                canDoubleJump = true;
            }
            else if(canDoubleJump)
            {
                canDoubleJump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower * 2);
            }
        }

        // Ability
        if (_takeover && Input.GetKey(KeyCode.E))
        {
            
            _enemy.Controlable = true;
            _player.enabled = false;
            _playershooting.enabled = false;
            _camtar.SetActive(false);
            Destroy(gameObject, 0.40f);
        }
    }

    void raycasting()
    {
        Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);

        grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
        


    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreLayerCollision(9, 10);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpecialEnemy"))
        {

            Debug.Log("Press E to take over!");
            _takeover = true;
        }
    }
}
