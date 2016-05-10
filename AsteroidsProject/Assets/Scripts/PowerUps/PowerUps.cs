using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{

	void Start ()
	{
		GameObject[] collectablesObjs = GameObject.FindGameObjectsWithTag ("Collectable");
	}

	void onTriggerEnter (Collider other)
	{
		if (other.tag == "Collectable") 
		{
			Destroy (other.gameObject);
		}
	}
}