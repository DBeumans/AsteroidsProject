using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CheckCollision : MonoBehaviour {


    // Use this for initialization

    bool respawn_front;
    bool respawn_back;
    Save _save;
    PlayerHealth _playerhealth;
    EnemyAi _enemyAI;

    void Start()
    {
        
        _playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        _save = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<Save>();
    }

    void Update()
    {
        _enemyAI = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAi>();
        if (_save.SaveCompleted)
        {
            _playerhealth.CurrentHealth = 0;
            SceneManager.LoadScene(2);
        }
    }


    void Respawn()
    {
        _save.SaveFile();
    }

	void OnTriggerEnter2D(Collider2D other)
    {
        // FRONT
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (this.gameObject.layer == LayerMask.NameToLayer("Death")) // kijken welke object actief is.
            {
                Respawn();
            }
            
        }

        // BACK
        if (other.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {
            if(this.gameObject.layer == LayerMask.NameToLayer("Death1")) // kijken welke object actief is.
            {
                Respawn();
            }
            
        }
       

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player1"))
        {

        }
    }
}
