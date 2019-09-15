using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject shield;
    public GameObject bow;

    public float moveSpeed = 10f;
    private Vector3 moveInput;
    private Vector3 moveVelocityShield;
    private Vector3 moveVelocityBow;
    private Rigidbody rbShield;
    private Rigidbody rbSword;
    private Transform transformShield;
    private Transform transformBow;


    public float timer = 1f;
    private float currentTime = 0f;
    public GameObject arrow;
    public Transform bow_obj;

    // Start is called before the first frame update
    void Start()
    {
        rbShield = shield.GetComponent<Rigidbody>();
        rbSword = bow.GetComponent<Rigidbody>();
        transformShield = shield.GetComponent<Transform>();
        transformBow = bow.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocityShield = moveVelocityBow = moveInput * moveSpeed;

        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("Mouse X") + Vector3.forward * Input.GetAxisRaw("Mouse Y");
        if (playerDirection.sqrMagnitude > 0.0f)
        {
            transformShield.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            transformBow.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }

        currentTime -= Time.deltaTime;
        if (currentTime < 0f)
        {
            currentTime = 0f;
        }

        if (Input.GetButton("Fire1"))
        {
            if (currentTime == 0f)
            {
                GameObject theArrow = Instantiate(arrow, transformBow.position, Quaternion.identity);
                arrow arrowScript = theArrow.GetComponent<arrow>();
                arrowScript.target = bow_obj;
                currentTime = timer;

            }
        }
    }

    private void FixedUpdate()
    {
        moveVelocityBow.y = rbSword.velocity.y;
        moveVelocityShield.y = rbShield.velocity.y;
        rbSword.velocity = moveVelocityBow;
        rbShield.velocity = moveVelocityBow;
    }
}
