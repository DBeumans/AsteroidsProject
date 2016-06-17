using UnityEngine;
using System.Collections;

public class Spawning_front : MonoBehaviour
{

    [SerializeField]
    Transform[] spawnPoints;
    [SerializeField]
    GameObject enemy;


    float time = 0f;
    float timestop;
    [SerializeField]
    float Seconds = 1;

    WaveManager _levelManager;

    public bool EnableSpawn = false;

    bool AbleSpawn;
    // Use this for initialization
    void Start()
    {
        
        timestop = 24 * Seconds + 1f;
        _levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WaveManager>();
    }
    void Update()
    {
        if(!_levelManager.WaveCap)
        {
            if (EnableSpawn)
            {
                AbleSpawn2(true);
            }
        }
        else
        {
            
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
        _levelManager.spawnAbleEnemies--;

    }
}
