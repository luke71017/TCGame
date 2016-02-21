using UnityEngine;
using System.Collections;

public class pgController : MonoBehaviour {

    public float forceMove;
    public float jumpSpeed;
    private Rigidbody rb;
    public bool readInput = true;
    public float MAX_SPEED;
    private bool grounded = true;

	private Vector3 leftForceMove;
	private Vector3 rightForceMove;

	private bool jumped = false;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

		leftForceMove = new Vector3 (-forceMove, 0f, 0f);
		rightForceMove = new Vector3 (forceMove, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	    if(readInput)
        {
			if (Input.GetKey (KeyCode.A))
				rb.AddForce (leftForceMove);
			else if (Input.GetKey (KeyCode.D))
				rb.AddForce (rightForceMove);
			else { //Si ferma istantaneamente quando non si preme un tasto
				rb.velocity = Vector3.up * rb.velocity.y;
			}

			//Limite alla velocità
			if (rb.velocity.x > MAX_SPEED) {
				rb.velocity = new Vector3 (MAX_SPEED, rb.velocity.y, 0f);
			}
			else if (rb.velocity.x < -MAX_SPEED)
				rb.velocity = new Vector3 (-MAX_SPEED, rb.velocity.y, 0f);

			//Raycast verifica che il PG sia per terra con soglia a 0.5f e con velocità nulla
            grounded = Physics.Raycast(transform.position, Vector3.down, 0.5f) && rb.velocity.y <= 0f;

            if (Input.GetKeyDown(KeyCode.W))
            {
				//Se tocca il terreno può saltare
				if (grounded) {
					jumped = true;

					rb.velocity += Vector3.up * jumpSpeed;
				} else if (jumped) {// Doppio salto se jumped è false
					jumped = false;

					rb.velocity += Vector3.up * (7.5f / (1f + Mathf.Abs(rb.velocity.y)));
				}
            }
        }
	}
}