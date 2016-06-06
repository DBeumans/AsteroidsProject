using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    float CurrentHealth = 100f;
    [SerializeField]
    float MaxHealth = 100f;

    
    public float GetDamage = 20;
	
	// Update is called once per frame
	void Update ()
    {
	    if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void RecieveDamage(float damage)
    {
        CurrentHealth = CurrentHealth - damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            RecieveDamage(GetDamage);
        }
    }
}
