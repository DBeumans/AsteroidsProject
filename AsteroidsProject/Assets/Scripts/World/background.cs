using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

    PlayerMovement _playermovement;
	// Use this for initialization
    void Start()
    {
        _playermovement = GameObject.FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (_playermovement.ChangeBackground)
        {
            this.transform.position = transform.position = new Vector3(0, 0, 40f);
            return;
        }
        else
        {
            this.transform.position = transform.position = new Vector3(0, 0, 19);
            return;
        }
    }
}
