using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_bow : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody myRigidBody;
    public GameObject arrow;
    public Transform bow;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Animator anim;
    private bool attack;
    public float timer = 1f;
    private float currentTime = 0f;
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
        currentTime -= Time.deltaTime;
        if(currentTime < 0f)
        {
            currentTime = 0f;
        }

        if (Input.GetButton("Fire1"))
        {
            moveInput = new Vector3(0f, 0f, 0f);
            if (currentTime == 0f)
            { 
                GameObject theArrow = Instantiate(arrow, transform.position, Quaternion.identity);
                arrow arrowScript = theArrow.GetComponent<arrow>();
                arrowScript.target = bow;
                currentTime = timer;

            }
        }
        else
        { 
            moveInput = new Vector3(Input.GetAxisRaw("Mouse X"), 0f, Input.GetAxisRaw("Mouse Y"));
        }
        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("Mouse X") + Vector3.forward * Input.GetAxisRaw("Mouse Y");
        transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
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
