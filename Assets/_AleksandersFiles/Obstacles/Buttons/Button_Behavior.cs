using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Behavior : MonoBehaviour
{
    public Exclusivity_Enum.exclusivity exclusiveTo;
    //public BoxCollider collisionDetection;

    //Communications
    public delegate void ButtonHandler();
    public event ButtonHandler ButtonHasBeenActivated;
    public event ButtonHandler ButtonHasBeenDeActivated;

    //Visual variables
    private Renderer render;
    private Color standardColor = Color.black;
    public Color activeColor = Color.green;

    //function variables
    public bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        setColor();

        //Set event calls
        ButtonHasBeenActivated += SetActive;
        ButtonHasBeenDeActivated += SetInactive;
    }

    private void setColor()
    {
        switch (exclusiveTo)
        {
            case Exclusivity_Enum.exclusivity.boy:      //case Boy
                standardColor = Color.blue;
                break;
            case Exclusivity_Enum.exclusivity.girl:     //case Girl
                standardColor = Color.red;
                break;
            default:                                    //case either
                standardColor = Color.yellow;
                break;
        }
        render.material.color = standardColor;
    }

    private void SetActive()
    {
        render.material.color = activeColor;
        isActive = true;
    }

    private void SetInactive()
    {
        render.material.color = standardColor;
        isActive = false;
    }



    //Collisions
    private void OnTriggerEnter(Collider other)
    {
        //Only activate if proper exclusive matches []
        if ( (other.gameObject.tag == "Shield" && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.boy)) 
            || (other.gameObject.tag == "sword" && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.girl)) 
            || (exclusiveTo.Equals(Exclusivity_Enum.exclusivity.either) && (other.gameObject.tag == "Shield" || other.gameObject.tag == "sword")) ) 
        {
            ButtonHasBeenActivated();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Only Deactivate if proper exclusive matches []
        if ((other.tag == "Shield" && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.boy))
            || (other.tag == "sword" && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.girl))
            || (exclusiveTo.Equals(Exclusivity_Enum.exclusivity.either) && (other.tag == "Shield" || other.tag == "sword")))
        {
            ButtonHasBeenDeActivated();
        }
    }
}
