using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float MovementSpeed = 7;
    [SerializeField]
    float SlamSpeed = 15;
    [SerializeField]
    float jumpPower = 20f;
    int teleportCounter;

    [SerializeField]
    Transform TeleportTarget;

    PlayerMovement _player;
    PlayerShooting _playershooting;

    SpecialEnemyAI _enemy;
    [SerializeField]
    Transform Playertransform;

    [SerializeField]
    GameObject _camtar;

    Animator anim;

    [SerializeField]
    bool grounded = false;

    [SerializeField]
    Transform groundedEnd;

    Rigidbody2D rb2d;

    bool canDoubleJump = false;

    bool _takeover = false;
    void Start()
    {
        // Get component function.
        GetComponent();
        SetValues();

        _camtar.SetActive(true);
        _player.enabled = true;
    }
    void SetValues()
    {
        teleportCounter = teleportCounter + 1;
    }
    void GetComponent()
    {
        _playershooting = GetComponent<PlayerShooting>();
        _player = GetComponent<PlayerMovement>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        //_enemy = GameObject.FindGameObjectWithTag("SpecialEnemy").GetComponent<SpecialEnemyAI>();
    }
    void FixedUpdate ()
    {
        Inputs();
         
	}

    void Update()
    {
        raycasting();
        CallAnimations();
    }
    void CallAnimations()
    {
        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.A)))
        {
            anim.SetBool("IsRunning", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("IsRunning", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("IsRunning", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("IsJumping", true);
            
        }
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
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(teleportCounter == 1)
            {
                Playertransform.transform.position += transform.position = new Vector3(0, 0, 20f);
                teleportCounter++;
            }
            else
            {
                Debug.Log("Cant go any further!");
            }
            

        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            if (teleportCounter == 2)
            {
                Playertransform.transform.position += transform.position = new Vector3(0, 0, -20);
                teleportCounter--;
            }
            else
            {
                Debug.Log("Cant go any further!");
            }

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

        if (other.gameObject.tag == "Teleport")
        {
            Playertransform.transform.position = TeleportTarget.transform.position;
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
