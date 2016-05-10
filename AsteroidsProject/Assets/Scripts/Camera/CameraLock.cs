using UnityEngine;
using System.Collections;

public class CameraLock: MonoBehaviour
{

    public Transform target;
    public float smoothTime;

    private Vector3 _velocity = Vector3.zero;
    private Vector3 _offset;
    // Use this for initialization
    void Start()
    {
        _offset = transform.position - target.position;
        target = GameObject.FindGameObjectWithTag("CamTarget").transform;
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("CamTarget").transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            Vector3 targetposition = target.position + _offset;
            // transform.position = target.position + _offset; 
            transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref _velocity, smoothTime);
        }
        else
        {
            //nothing
            Debug.Log(" nothing ");

        }

    }
}