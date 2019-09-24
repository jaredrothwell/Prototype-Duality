using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
    public Exclusivity_Enum.exclusivity exclusiveTo;

    public float lifeTime; //Bullet has a lifetime of 3 seconds
    public float movementSpeed = 5f;

    //Visual variables
    private Renderer render;
    private Color standardColor = Color.black;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        setColor();
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
    }

    // Start is called before the first frame update
    void Start()
    {
        //if(lifeTime > 0)
        //{
        //    // Destroy the bullet after x seconds of firing
        //    Destroy(this.gameObject, lifeTime);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    //Collisions
    private void OnTriggerEnter(Collider other)
    {
        //Only kill if exclusivity doesnt match
        if ((other.gameObject.tag == "Shield" && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.girl))
            || (other.gameObject.tag == "sword" && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.boy))
            || ((other.gameObject.tag == "Shield" || other.gameObject.tag == "sword") && exclusiveTo.Equals(Exclusivity_Enum.exclusivity.either)) )
        {
            //kill other
            other.GetComponent<Player_Behavior>().Death();
            Destroy(gameObject);
        }
        //Make sure to check and not destroy if it collides with a bullet or shooter
        if(other.gameObject.tag != "bullet" && other.gameObject.tag != "Shooter")
        {
            Destroy(gameObject);
        }
    }
}
