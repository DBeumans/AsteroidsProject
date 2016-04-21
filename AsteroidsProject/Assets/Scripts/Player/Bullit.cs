using UnityEngine;
using System.Collections;

public class Bullit : MonoBehaviour {

    [SerializeField]
    float speed;
	// Use this for initialization
	void Start ()
    {
        //Destroy(gameObject, 0.40f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}
