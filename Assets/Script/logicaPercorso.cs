using UnityEngine;
using System.Collections;

public class logicaPercorso : MonoBehaviour {

	public GameObject pg;
	private bool grounded = true;
	private Rigidbody rb;
	private BoxCollider boxCollider;

	// Use this for initialization
	void Start () {
		rb = pg.GetComponent<Rigidbody>();
		boxCollider = GetComponent<BoxCollider> ();
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit = new RaycastHit();

		//Raycast verifica che il PG sia per terra con soglia a 0.5f e con velocità nulla
		grounded = Physics.Raycast(pg.transform.position, Vector3.down, out hit, 0.5f) && rb.velocity.y <= 0f;

		if (grounded && hit.collider.Equals(boxCollider)) {
			print ("fine livello");
		}
	}
}
