using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiarnyTestScript : MonoBehaviour
{
	public float speed = 1f;

	private Rigidbody rig;


	// Start is called before the first frame update
	void Start()
    {
		rig = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
		float hAxis = Input.GetAxis("Horizontal");
		Vector3 movement = new Vector3(hAxis, 0, 0) * speed * Time.deltaTime;
		rig.MovePosition(transform.position + movement);
	}
}
