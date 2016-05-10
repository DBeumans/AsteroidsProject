using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    [SerializeField]
    float health;
    

	// Use this for initialization
	void Start ()
    {
        if (gameObject.tag == "Enemy")
        {
            health = 50.00f;
        }
        else if(gameObject.tag == "SpecialEnemy")
        {
            health = 150.00f;
        }

    }
	
	// Update is called once per frame
	void Update ()
    {

	}
}
