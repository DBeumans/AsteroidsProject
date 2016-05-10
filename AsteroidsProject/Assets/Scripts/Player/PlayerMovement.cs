using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float MovementSpeed;
    [SerializeField]
    float turnSpeed;

    PlayerMovement _player;
    PlayerShooting _playershooting;

    SpecialEnemyAI _enemy;

    [SerializeField]
    GameObject _camtar;

    bool _takeover = false;
    // Update is called once per frame
    void Start()
    {
        
        _enemy = GameObject.FindGameObjectWithTag("SpecialEnemy").GetComponent<SpecialEnemyAI>();
        
        _camtar.SetActive(true);

        
        _player = GetComponent<PlayerMovement>();
        _player.enabled = true;

        _playershooting = GetComponent<PlayerShooting>();
    }
	void FixedUpdate ()
    {
        MovementHandler();
        Inputs();

        
	}

    void MovementHandler()
    {
        if(Input.GetKey(KeyCode.A)) // LINKS
        {
            transform.Rotate(new Vector3(0,0,turnSpeed) * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.D)) // RECHTS
        {
            transform.Rotate(new Vector3(0,0, -turnSpeed) * Time.deltaTime);


        }

        if (Input.GetKey(KeyCode.W)) // UP
        {
            transform.Translate(Vector3.up * MovementSpeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S)) // DOWN
        {
            transform.Translate(-Vector3.up * MovementSpeed * Time.deltaTime);

        }
    }

    void Inputs()
    {
        if(_takeover && Input.GetKey(KeyCode.E))
        {
            
            _enemy.Controlable = true;
            _player.enabled = false;
            _playershooting.enabled = false;
            _camtar.SetActive(false);
            Destroy(gameObject, 0.40f);
        }
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
