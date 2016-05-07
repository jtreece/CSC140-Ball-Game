using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    GameObject map;
    Rigidbody rb;
    Vector3 mouse_start_position;
    bool old_mouse_state;
    bool moving;
    float y_rotation;

	// Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        map = GameObject.Find("ball_game_map");
        old_mouse_state = false;
        y_rotation = 0.0f;
        //Physics.IgnoreCollision(GetComponent<Collider>(), map.GetComponents<Collider>()[1]);
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !old_mouse_state)
        {
            rb.isKinematic = true;
            old_mouse_state = true;
            mouse_start_position = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            rb.isKinematic = false;
            old_mouse_state = false;
            rb.AddForce(this.transform.forward * (Input.mousePosition - mouse_start_position).magnitude + this.transform.up *  (Input.mousePosition - mouse_start_position).magnitude);
            moving = true;
        }
        if (!old_mouse_state && !moving)
        {
            y_rotation += Input.GetAxis("Mouse X") * 0.1f;
            transform.eulerAngles += new Vector3(0, y_rotation, 0);
        }
	}

    void OnCollisionEnter()
    {
        rb.isKinematic = true;
        moving = false;
    }

    void OnTriggerEnter(Collider other)
    {
        GUI.Label(new Rect(Screen.height - 10, Screen.width-40, 20, 80), "You win!");
    }
}
