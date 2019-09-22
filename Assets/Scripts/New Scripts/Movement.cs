using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject shield;
    public GameObject bow;

    public float moveSpeed = 10f;
    private Vector3 moveInputShield;
    private Vector3 moveInputBow;
    private Vector3 moveVelocityShield;
    private Vector3 moveVelocityBow;
    private Rigidbody rbShield;
    private Rigidbody rbBow;
    private Transform transformShield;
    private Transform transformBow;


    public float timer = 1f;
    private float currentTime = 0f;
    public GameObject arrow;
    public Transform bow_obj;
    public float HorizontalShield;
    public float HorizontalBow;
    public float VerticalShield;
    public float VerticalBow;
    public float rotateShield = 0;
    public float rotateBow = 0;

    public bool link = true;

    // Start is called before the first frame update
    void Start()
    {
        rbShield = shield.GetComponent<Rigidbody>();
        rbBow = bow.GetComponent<Rigidbody>();
        transformShield = shield.GetComponent<Transform>();
        transformBow = bow.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            link = !link;

        if (link)
            linked();
        else
            unlinked();
    }

    private void unlinked()
    {
        //Sword and bow player
        currentTime -= Time.deltaTime;
        if (currentTime < 0f)
        {
            currentTime = 0f;
        }

        if (Input.GetButton("Fire1"))
        {
            moveInputBow = new Vector3(0f, 0f, 0f);
            if (currentTime == 0f)
            {
                GameObject theArrow = Instantiate(arrow, transformBow.position, Quaternion.identity);
                arrow arrowScript = theArrow.GetComponent<arrow>();
                arrowScript.target = bow_obj;
                currentTime = timer;

            }
        }
        else
        {
            moveInputBow = new Vector3(Input.GetAxisRaw("Mouse X"), 0f, Input.GetAxisRaw("Mouse Y"));
        }

        Vector3 playerDirectionBow = Vector3.right * Input.GetAxisRaw("Mouse X") + Vector3.forward * Input.GetAxisRaw("Mouse Y");
        transformBow.rotation = Quaternion.LookRotation(playerDirectionBow, Vector3.up);
        moveVelocityBow = moveInputBow * moveSpeed;


        //Shield player
        moveInputShield = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocityShield = moveInputShield * moveSpeed;

        if (!Input.GetButton("Fire2"))
        {
            Vector3 playerDirectionShield = Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.forward * Input.GetAxisRaw("Vertical");
            if (playerDirectionShield.sqrMagnitude > 0.0f)
            {
                transformShield.rotation = Quaternion.LookRotation(playerDirectionShield, Vector3.up);
            }
        }
    }

    private void linked()
    {
        HorizontalShield = Input.GetAxisRaw("Horizontal");
        HorizontalBow = Input.GetAxisRaw("Horizontal");
        VerticalShield = Input.GetAxisRaw("Vertical");
        VerticalBow = Input.GetAxisRaw("Vertical");
        moveInputShield = rotatePointAroundAxis(new Vector3(HorizontalShield, 0f, VerticalShield), rotateShield, new Vector3(0, 1, 0));
        moveInputBow = rotatePointAroundAxis(new Vector3(HorizontalBow, 0f, VerticalBow), rotateBow, new Vector3(0, 1, 0));
        moveVelocityShield = moveInputShield * moveSpeed;
        moveVelocityBow = moveInputBow * moveSpeed;

        Vector3 playerDirectionShield = rotatePointAroundAxis(Vector3.right * Input.GetAxisRaw("Mouse X") + Vector3.forward * Input.GetAxisRaw("Mouse Y"), rotateShield, new Vector3(0, 1, 0));
        Vector3 playerDirectionBow = rotatePointAroundAxis(Vector3.right * Input.GetAxisRaw("Mouse X") + Vector3.forward * Input.GetAxisRaw("Mouse Y"), rotateBow, new Vector3(0, 1, 0));
        if (playerDirectionShield.sqrMagnitude > 0.0f)
        {
            transformShield.rotation = Quaternion.LookRotation(playerDirectionShield, Vector3.up);
        }
        if (playerDirectionBow.sqrMagnitude > 0.0f)
        {
            transformBow.rotation = Quaternion.LookRotation(playerDirectionBow, Vector3.up);
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
        moveVelocityBow.y = rbBow.velocity.y;
        moveVelocityShield.y = rbShield.velocity.y;
        rbBow.velocity = moveVelocityBow;
        rbShield.velocity = moveVelocityShield;
    }

    private Vector3 rotatePointAroundAxis(Vector3 point, float angle, Vector3 axis)
    {
        Quaternion q = Quaternion.AngleAxis(angle, axis);
        return q * point; //Note: q must be first (point * q wouldn't compile)
    }
}
