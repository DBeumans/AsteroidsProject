using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {


    public int CurrentEnemies;

    int DefaultSpawnAbleEnemies = 4; // standard enemies on field.
    public int spawnAbleEnemies;
    [SerializeField]
    int MaxEnemies = 10000;

    GameObject[] EnemyObjecten;

    public bool WaveCap;
    public bool stopSpawn;

    
    public int waveCounter = 1;

    // Use this for initialization
    void Start () {
        spawnAbleEnemies += DefaultSpawnAbleEnemies;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckEnemiesInScene();

        EnemyObjecten = GameObject.FindGameObjectsWithTag("Enemy"); // zoek game object met tag Enemy en zet het in een array.

        CurrentEnemies = EnemyObjecten.Length; // aantal items in array in een int variable zetten om te zien hoeveel erin zit.

    }

    void Reset()
    {
        stopSpawn = false;
        WaveCap = false;
        waveCounter++;
        DefaultSpawnAbleEnemies += 2;
        spawnAbleEnemies += DefaultSpawnAbleEnemies + DefaultSpawnAbleEnemies/2;
        
        
    }
    void CheckEnemiesInScene()
    {
        if (spawnAbleEnemies == 0)
        {

            stopSpawn = true;

        }
        if (CurrentEnemies == 0 && spawnAbleEnemies == 0)
        {

            Reset();
        }


        if (CurrentEnemies == MaxEnemies)
        {
            stopSpawn = true;
        }
        if (CurrentEnemies != MaxEnemies)
        {
            WaveCap = false;
        }

        if (stopSpawn)
        {
            WaveCap = true;
        }
    }

}
