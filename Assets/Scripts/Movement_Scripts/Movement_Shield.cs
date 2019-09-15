using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Shield : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Transform toRotate;

    // Start is called before the first frame update
    void Start()
    {
        //moveSpeed = 15f;
        myRigidBody = GetComponent<Rigidbody>();
        toRotate = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        if (!Input.GetButton("Fire2"))
        { 
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
        }
    }
    private void FixedUpdate()
    {
        moveVelocity.y = myRigidBody.velocity.y;
        myRigidBody.velocity = moveVelocity;
        
    }
}
