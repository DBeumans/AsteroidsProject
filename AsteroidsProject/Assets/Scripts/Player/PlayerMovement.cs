using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization

    [SerializeField]
    float playerspeed = 10f;
    [SerializeField]
    float jumpPower = 20f;

    [SerializeField]
    bool grounded = false;

    [SerializeField]
    Transform  groundedEnd;

    Rigidbody2D rb2d;

    void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerMovementHandler();
        raycasting();
	}

    void raycasting()
    {
        Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);

        grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));

    }

    void PlayerMovementHandler()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 4f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * 4f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }
    }
}
