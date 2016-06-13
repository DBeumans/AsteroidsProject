using UnityEngine;
using System.Collections;

public class OnHoverover : MonoBehaviour {

    AudioSource _audiosource;
    [SerializeField]
    AudioClip sound;

	// Use this for initialization
	void Start () {
        _audiosource = gameObject.GetComponent<AudioSource>();
	
	}

    public void Hover()
    {
        //Debug.Log("works");
        _audiosource.PlayOneShot(sound);   
    }

}
