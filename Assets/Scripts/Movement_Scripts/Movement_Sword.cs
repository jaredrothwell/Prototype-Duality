using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Sword : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody myRigidBody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Animator anim;
    private bool attack;

    // Start is called before the first frame update
    void Start()
    {
       //moveSpeed = 15f;
        myRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        attack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Fire1") && !attack)
        {
            moveInput = new Vector3(Input.GetAxisRaw("Mouse X"), 0f, Input.GetAxisRaw("Mouse Y"));
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("Mouse X") + Vector3.forward * Input.GetAxisRaw("Mouse Y");
            if (playerDirection.sqrMagnitude > 0.0f)
            {
                transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            }
        }
        else
        {
            attack = true;
            anim.SetBool("attack", true);
            moveInput = new Vector3(Input.GetAxisRaw("Mouse X"), 0f, Input.GetAxisRaw("Mouse Y"));
            Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("Mouse X") + Vector3.forward * Input.GetAxisRaw("Mouse Y");
        }
        moveVelocity = moveInput * moveSpeed;
    }
    private void FixedUpdate()
    {
        moveVelocity.y = myRigidBody.velocity.y;
        myRigidBody.velocity = moveVelocity;
    }

    private void resetAttack()
    {
        anim.SetBool("attack", false);
        attack = false;
    }
}
