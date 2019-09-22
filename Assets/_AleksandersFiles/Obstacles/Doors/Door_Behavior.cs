using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Behavior : MonoBehaviour
{
    public List<Button_Behavior> ButtonsToActivate;
    public bool isOpen = false;
    public float doorOpenHeight = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //get list of buttons
        //attach all of their isactive behaviors to a door function
        foreach (Button_Behavior button in ButtonsToActivate)
        {
            button.ButtonHasBeenActivated += ButtonHasBeenPressed;
        }
        //do same for deactivate
        
    }

    //If a button has been pressed, then check if all buttons have been pressed
    void ButtonHasBeenPressed()
    {
        bool allButtonsPressed = true;
        foreach (Button_Behavior button in ButtonsToActivate)
        {
            if(!button.isActive)
            {
                allButtonsPressed = false;
            }
        }

        if(allButtonsPressed)
        {
            OpenDoor();
        }
    }

    //Make door function that when called will recieve which button is active and try to determine if all buttons are active.

    //Open Door function
    private void OpenDoor()
    {
        if(!isOpen)
        {
            isOpen = true;
            Renderer render = GetComponent<Renderer>();
            render.material.color = Color.green;
            transform.localPosition = transform.localPosition + new Vector3(0f, doorOpenHeight);
        }
        
    }
}
