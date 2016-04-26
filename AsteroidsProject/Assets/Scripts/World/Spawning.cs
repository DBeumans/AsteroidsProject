using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    GameObject enemy;
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

    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
