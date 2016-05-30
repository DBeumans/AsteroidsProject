using UnityEngine;
using System.Collections;

public class Bullit : MonoBehaviour {

    [SerializeField]
    float speed;

    void Start()
    {
        Destroy(gameObject, 0.40f);
    }

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Enemy Hitted!");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

}
