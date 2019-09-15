using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Movement : MonoBehaviour
{
    public float timer = 5f;
    public float moveSpeed = 10f;
    private float totalTime = 0f;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Rigidbody myRigidBody;
    private bool check;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        check = true;
        totalTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        updateTimer();
        if (check)
        {
            moveInput = new Vector3(0f, 0f, 1f);
        }
        else
        {
            moveInput = new Vector3(0f, 0f, -1f);
        }
        moveVelocity = moveInput * moveSpeed;
    }

    private void FixedUpdate()
    {
        moveVelocity.y = myRigidBody.velocity.y;
        myRigidBody.velocity = moveVelocity;

    }

    private void updateTimer()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            check = !check;
            timer = totalTime;
        }
    }
}
