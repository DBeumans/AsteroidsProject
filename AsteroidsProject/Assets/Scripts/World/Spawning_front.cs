using UnityEngine;
using System.Collections;

public class Spawning_front : MonoBehaviour {

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    float SpawnTime = 0.01f;

    bool EnableSpawn = false;

    PlayerMovement player;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if(EnableSpawn)
        {
            InvokeRepeating("Spawn", SpawnTime, SpawnTime);
        }
    }
    void Update()
    {
        if (player.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            EnableSpawn = true;
        }
        if(player.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            EnableSpawn = false;
        }
    }
    void Spawn()
    {

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
