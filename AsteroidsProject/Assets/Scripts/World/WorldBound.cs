using UnityEngine;
using System.Collections;

public class WorldBound : MonoBehaviour {

    [SerializeField]
    Transform pos;
    //[SerializeField]
    Transform player;
	
    void Start()
    {
          
    }
	// Update is called once per frame
	void Update ()
    {
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            player.transform.position = pos.transform.position;
        }
    }
}
