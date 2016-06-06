using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {

    ScoreHandler _ScoreHandler;
    EnemyHealth _EnemyHealth;
    Bullet _Bullet;

    void Start()
    {
        _ScoreHandler = gameObject.GetComponent<ScoreHandler>();
        
        _Bullet = gameObject.GetComponent<Bullet>();
    }

    void Update()
    {
        //_EnemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
    }


    public void Upgrade_Gun()
    {
        
    }

}