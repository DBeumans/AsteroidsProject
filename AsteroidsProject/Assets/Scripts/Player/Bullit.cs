using UnityEngine;
using System.Collections;

public class Bullit : MonoBehaviour {

    [SerializeField]
    float speed;

    PlayerMovement player;

    EnemyHealth _enemyHealth;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Destroy(gameObject, 0.40f);
    }

    void Update()
    {

        
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(player.teleportCounter == 1)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Bullet");
        }
        if(player.teleportCounter == 2)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Bullet1");
        }
    }

 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("GROUND HITTED!");
        }
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

}
