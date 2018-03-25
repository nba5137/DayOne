using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public LayerMask ground_layer;
    public SphereCollider feetCollider;

    Rigidbody playerRigidbody;
    float speed = 2.5f;
    float jump_force = 5f;
    Vector3 movement;

    void Awake () {
        playerRigidbody = GetComponent<Rigidbody>();
        feetCollider = GetComponent<SphereCollider>();
    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        // Making diagonal speed as same as default. 
        movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        movement = movement/*.normalized*/ * speed * Time.deltaTime;
        //playerRigidbody.MovePosition(transform.position + movement);
        transform.Translate(movement);

        // Jump
        if (Input.GetButtonDown("Jump") && Check_Grounded())
        {
            playerRigidbody.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        }
    }

    private bool Check_Grounded()
    {
        return Physics.CheckCapsule(feetCollider.bounds.center, new Vector3(feetCollider.bounds.center.x, 
            feetCollider.bounds.min.y, feetCollider.bounds.center.z), feetCollider.radius * 0.9f, ground_layer);
    }
}
