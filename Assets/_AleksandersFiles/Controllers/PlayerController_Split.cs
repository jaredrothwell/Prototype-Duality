using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_Split : MonoBehaviour
{
    PlayerControls_Split controls;
    public CharacterController controller;
    public bool isLeftChar;

    Vector2 LeftMovement;
    Vector2 RightMovement;

    public float movementSpeed = 10; //Default 10
    public float gravityScale = 1;  //Default 1

    private void Awake()
    {
        //Map Input and controls.
        controls = new PlayerControls_Split();
        controller = GetComponent<CharacterController>();
        //EXAMPLE CASE: controls.Gameplay.Action.performed += ctx => Grow();

        //Use lambda expressions
        controls.Split_Gameplay.LeftCharMovement.performed += ctx => LeftMovement = ctx.ReadValue<Vector2>();
        controls.Split_Gameplay.LeftCharMovement.canceled += ctx => LeftMovement = Vector2.zero;
        controls.Split_Gameplay.RightCharMovement.performed += ctx => RightMovement = ctx.ReadValue<Vector2>();
        controls.Split_Gameplay.RightCharMovement.canceled += ctx => RightMovement = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Split_Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Split_Gameplay.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeftChar)
        {
            //Left Character Movement
            Vector3 lM = new Vector3(LeftMovement.x * movementSpeed, 0f, LeftMovement.y * movementSpeed);
            lM.y = lM.y + (Physics.gravity.y * gravityScale);
            controller.Move(lM * Time.deltaTime);
            //Left Character Rotation
            //TODO Implement
        }
        else
        {
            //Right Character Movement
            Vector3 rM = new Vector3(RightMovement.x * movementSpeed, 0f, RightMovement.y * movementSpeed);
            rM.y = rM.y + (Physics.gravity.y * gravityScale);
            controller.Move(rM * Time.deltaTime);
        }
        

    }
}
