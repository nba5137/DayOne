using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    //Rigidbody playerRigidbody;
    //Camera cam;
    float speed = 2.5f;
    Vector3 movement;
    int health;
    Quaternion cam_move;

	void Start () {
        //playerRigidbody = GetComponent<Rigidbody>();
        //cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per physics frame
    void FixedUpdate () {
        // Making diagonal speed as same as default. 
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movement = movement/*.normalized*/ * speed * Time.deltaTime;
        //playerRigidbody.MovePosition(transform.position + movement);
        transform.Translate(movement);
    }

}
