using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

    [SerializeField]
    Transform[] SpawnPoints;
    [SerializeField]
    GameObject Enemy;
    [SerializeField]
    float SpawnTime = 0.01f;
	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn", SpawnTime, SpawnTime);
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
