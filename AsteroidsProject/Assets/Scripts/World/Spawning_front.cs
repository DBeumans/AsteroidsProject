using UnityEngine;
using System.Collections;

public class Spawning_front : MonoBehaviour
{

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    GameObject enemy;
    [SerializeField]

    float time = 0f;
    [SerializeField]
    float timestop = 96f;

    public bool EnableSpawn = false;

    bool AbleSpawn;
    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        if (EnableSpawn)
        {
            AbleSpawn2(true);
        }
    }

    void AbleSpawn2(bool value)
    {
        if (value)
        {
            time++;
            if (time >= timestop)
            {
                Spawn();
                time = 0f;
            }

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
