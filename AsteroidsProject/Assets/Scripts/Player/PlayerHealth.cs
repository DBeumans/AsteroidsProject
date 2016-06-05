using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    float CurrentHealth;
    [SerializeField]
    float MaxHealth;

	// Use this for initialization
	void Start ()
    {
        MaxHealth = 3f;
        CurrentHealth = 3f;
        

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void GetDamage(int damage)
    {
        CurrentHealth = CurrentHealth - damage;
        Debug.Log(CurrentHealth);
    }
}
