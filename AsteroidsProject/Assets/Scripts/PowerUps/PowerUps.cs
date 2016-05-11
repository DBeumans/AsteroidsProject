using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{

	void Start ()
	{
		//GameObject[] collectablesObjs = GameObject.FindGameObjectsWithTag ("Collectable");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Collectable")) 
		{
<<<<<<< HEAD
            Debug.Log("Collectable");
=======
			Debug.Log ("powerup");
			Destroy (other.gameObject);
>>>>>>> origin/master
		}
	}
}