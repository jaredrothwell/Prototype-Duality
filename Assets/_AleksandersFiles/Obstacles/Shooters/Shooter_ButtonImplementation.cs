using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_ButtonImplementation : Shooter_Behavior
{
    public List<Button_Behavior> ButtonsToActivate;
    public bool buttonsDisableShooter;              // if true, buttons turn off; else buttons change behavior
    public bool needsAllButtonsToChange;            // if true, then requires all buttons to be on to enable behavior changes

    private Exclusivity_Enum.exclusivity baseExclusivity;
    public Exclusivity_Enum.exclusivity onChangeExclusivity = Exclusivity_Enum.exclusivity.either;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        baseExclusivity = exclusiveTo;
        foreach (Button_Behavior button in ButtonsToActivate)
        {
            button.ButtonHasBeenActivated += this.ButtonHasBeenActivated;
            button.ButtonHasBeenDeActivated += this.ButtonHasBeenDeactivated;
        }
    }

    void ButtonHasBeenActivated()
    {
        if(buttonsDisableShooter)
        {
            if(needsAllButtonsToChange)
            {
                //Check if all buttons
                if(AllButtonsActive())
                {
                    this.Deactivate();
                }
            }
            else
            {
                this.Deactivate();
            }
        }
        else    //Buttons change behavior
        {
            if (needsAllButtonsToChange)
            {
                //Check if all buttons
                if (AllButtonsActive())
                {
                    exclusiveTo = onChangeExclusivity;
                    this.UpdateShooter();
                }
            }
            else
            {
                exclusiveTo = onChangeExclusivity;
                this.UpdateShooter();
            }
        }
    }

    void ButtonHasBeenDeactivated()
    {
        if (buttonsDisableShooter)
        {
            //If just one button is removed then shooter will shoot
            if(needsAllButtonsToChange)
            {
                this.Activate();
            }
            else    //Any one of the buttons can be pressed to turn off the shooter
            {
                if(AllButtonsDeactive())
                {
                    //If all buttons are off then turn on the shooter
                    this.Activate();
                }
            }
        }
        else    //Buttons change behavior
        {
            if (needsAllButtonsToChange)
            {
                //If just one button is off then revert changes
                exclusiveTo = baseExclusivity;
                this.UpdateShooter();
            }
            else
            {
                //make sure all buttons are deactivated before reverting changes
                if(AllButtonsDeactive())
                {
                    exclusiveTo = baseExclusivity;
                    this.UpdateShooter();
                }
            }
        }
    }

    //Check if all buttons are active [If false, atleast one button is not active]
    private bool AllButtonsActive()
    {
        bool allButtonsPressed = true;
        foreach (Button_Behavior button in ButtonsToActivate)
        {
            if (!button.isActive)
            {
                allButtonsPressed = false;
            }
        }

        return allButtonsPressed;
    }

    //Check if all buttons are not active [If false, atleast one button is active]
    private bool AllButtonsDeactive()
    {
        bool allButtonsNotPressed = true;
        foreach (Button_Behavior button in ButtonsToActivate)
        {
            if (button.isActive)
            {
                allButtonsNotPressed = false;
            }
        }

        return allButtonsNotPressed;
    }

    //Update shooter incase of a change
    private void UpdateShooter()
    {
        this.Deactivate();
        this.Activate();
    }
    
}
