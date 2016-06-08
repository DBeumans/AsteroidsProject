using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    CheckCollision _checkCol;

    public float lives;

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
        lives = 3;
        MaxHealth = 100f;
        CurrentHealth = 100f;

        defaultTimeState = 24f * seconds + 12f;
        timer = defaultTimeState;
    
    }
    
    void Update()
    {
        _checkCol = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<CheckCollision>();
        if (AttackCooldown)
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

            if (lives <= 0)
            {
                _checkCol.Respawn();
            }
            else
            {
                lives--;
                CurrentHealth = MaxHealth;
            }
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
