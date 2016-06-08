using UnityEngine;
using System.Collections;

public class EnemyCollisionCheck : MonoBehaviour {

    [SerializeField]
    EnemyAi _enemy;
	// Use this for initialization
	void Start () {
       

    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _enemy.EnemyTransform();   
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {

        }
    }
}
