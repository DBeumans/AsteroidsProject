using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    CheckCollision _checkCol;
    
    public float CurrentHealth;
    [SerializeField]
    float MaxHealth;

    [SerializeField]
    bool AttackCooldown;

    float defaultTimeState;
    [SerializeField]
    float timer;
    [SerializeField]
    float seconds;

    // Use this for initialization
    void Start ()
    {
        _checkCol = GameObject.FindGameObjectWithTag("Look_Front").GetComponent<CheckCollision>();
        MaxHealth = 3f;
        CurrentHealth = 3f;

        defaultTimeState = 24f * seconds + 12f;
        timer = defaultTimeState;
    
    }
    
    void Update()
    {

        if(AttackCooldown)
        {
            timer--;
            
        }
        if (timer <= 0)
        {
            timer = defaultTimeState;
            AttackCooldown = false;
        }

        if (CurrentHealth <= 0)
        {
            _checkCol.Respawn();
        }
    }
    public void GetDamage(float damage)
    {
        if(!AttackCooldown)
        {
            CurrentHealth = CurrentHealth - damage;
            AttackCooldown = true;
            Debug.Log(CurrentHealth);
        }
        else
        {
           // Debug.Log("nothing");
        }
        
        
    }
}
