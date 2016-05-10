using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    [SerializeField]
    float playerHealth;

    [SerializeField]
    float specialAttackExp;
    [SerializeField]
    bool specialAttack;
    EnemyAi _enemy;

	// Use this for initialization
	void Start () {
        
        playerHealth = 100.00f;
        _enemy = GetComponent<EnemyAi>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
