using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    SpringJoint spring;
    Rigidbody rb;
    Ray mouse_ray;
    RaycastHit ray_hit;

	// Use this for initialization
	void Start () {
	    rb = GetComponent<Rigidbody>();
        mouse_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(mouse_ray, out ray_hit, 100.0f))
        {
            rb.isKinematic = true;
        }
        if (Input.GetMouseButtonUp(0))
            rb.isKinematic = false;
	}
}
