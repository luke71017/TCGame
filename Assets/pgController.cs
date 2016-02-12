using UnityEngine;
using System.Collections;

public class pgController : MonoBehaviour {

    public float acceleration;
    public float jumpSpeed;
    private Rigidbody rb;
    public bool readInput = true;
    public float MAX_SPEED;
    private bool grounded = true;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(readInput)
        {
            //float hMovement = Input.GetAxis("Horizontal");
            if (Input.GetKey(KeyCode.A))
                rb.AddForce(new Vector3(-acceleration, 0f, 0f));
            else if (Input.GetKey(KeyCode.D))
                rb.AddForce(new Vector3(acceleration, 0f, 0f));
            else
                rb.velocity = new Vector3(0f, rb.velocity.y, 0f);

            if (rb.velocity.x > MAX_SPEED)
                rb.velocity = new Vector3(MAX_SPEED, rb.velocity.y, 0f);
            else if (rb.velocity.x < -MAX_SPEED)
                rb.velocity = new Vector3(-MAX_SPEED, rb.velocity.y, 0f);

            grounded = Physics.Raycast(transform.position, Vector3.down, 0.5f) && rb.velocity.y <= 0f;

            if (Input.GetKeyDown(KeyCode.W) && grounded)
            {
                rb.velocity += Vector3.up * jumpSpeed;
            }

            print(rb.position);
        }
	}
}