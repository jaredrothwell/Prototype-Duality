using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; //Remove when using proper respawning

[RequireComponent(typeof(Collider))]
public class DeathFloor_Behavior : MonoBehaviour
{
    public Exclusivity_Enum.exclusivity exclusiveTo;
    public Exclusivity_Enum.exclusivity exclusiveWhenActive;
    //public BoxCollider collisionDetection;

    //Communications
    public List<Button_Behavior> ButtonsToActivate;
    public BoxCollider DeathZone; //Must be a trigger for the floor

    //Visual variables
    private Renderer render;
    private Color standardColor = Color.black;
    private Color activeColor = Color.green;

    private bool isActive = false;
    

    // Start is called before the first frame update
    void Start()
    {
        //Set exclusive Color
        render = GetComponent<Renderer>();
        setColor();

        //get list of buttons
        //attach all of their isactive behaviors to a door function
        foreach (Button_Behavior button in ButtonsToActivate)
        {
            button.ButtonHasBeenActivated += ButtonHasBeenPressed;
            button.ButtonHasBeenDeActivated += ButtonHasBeenReleased;
        }
        //do same for deactivate
    }

    private void setColor()
    {
        //Set standard color (When not active)
        switch (exclusiveTo)
        {
            case Exclusivity_Enum.exclusivity.boy:      //case Boy
                standardColor = Color.blue;
                break;
            case Exclusivity_Enum.exclusivity.girl:     //case Girl
                standardColor = Color.red;
                break;
            default:                                    //case either
                standardColor = Color.black;
                break;
        }
        render.material.color = standardColor;

        //Set active color
        switch (exclusiveWhenActive)
        {
            case Exclusivity_Enum.exclusivity.boy:      //case Boy
                activeColor = Color.blue;
                break;
            case Exclusivity_Enum.exclusivity.girl:     //case Girl
                activeColor = Color.red;
                break;
            default:                                    //case either
                activeColor = Color.black;
                break;
        }
    }

    //If a button has been pressed, set active
    void ButtonHasBeenPressed()
    {
        SetActive();
    }

    //If as button has been released, make sure all buttons are released before going inactive
    private void ButtonHasBeenReleased()
    {
        bool allButtonsReleased = true;
        foreach (Button_Behavior button in ButtonsToActivate)
        {
            if (button.isActive)
            {
                allButtonsReleased = false;
            }
        }

        if (allButtonsReleased)
        {
            SetInactive();
        }
    }

    private void SetActive()
    {
        render.material.color = activeColor;
        isActive = true;
        //Reset DeathZone
        DeathZone.enabled = false;
        DeathZone.enabled = true;
    }

    private void SetInactive()
    {
        render.material.color = standardColor;
        isActive = false;
        //Reset DeathZone
        DeathZone.enabled = false;
        DeathZone.enabled = true;
    }

    //Collisions
    private void OnTriggerEnter(Collider other)
    {
        if(isActive)
        {
            //Only kill if exclusivity doesnt match
            if ((other.gameObject.tag == "Shield" && exclusiveWhenActive.Equals(Exclusivity_Enum.exclusivity.girl))
                || (other.gameObject.tag == "sword" && exclusiveWhenActive.Equals(Exclusivity_Enum.exclusivity.boy)) 
                || ((other.gameObject.tag == "Shield" || other.gameObject.tag == "sword") && exclusiveWhenActive.Equals(Exclusivity_Enum.exclusivity.either)) )
            {
                //kill other
                //other.GetComponent<Player_Behavior>().Death();
                //Temporary until respawning is complete
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
        else
        {
            //Only kill if exclusivity doesnt match
            if ( (other.gameObject.tag == "Shield" && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.girl))
                || (other.gameObject.tag == "sword" && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.boy)) 
                || ((other.gameObject.tag == "Shield" || other.gameObject.tag == "sword") && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.either)) )
            {
                //kill other
                //other.GetComponent<Player_Behavior>().Death();
                //Temporary until respawning is complete
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
