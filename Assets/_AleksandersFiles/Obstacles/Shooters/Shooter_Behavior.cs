﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_Behavior : MonoBehaviour
{
    public Exclusivity_Enum.exclusivity exclusiveTo = Exclusivity_Enum.exclusivity.either;

    //Bullet Variables
    public GameObject bullet;
    public float shootSpeed = .3f;       //How long to wait between each bullet
    public float bulletMovementSpeed = 5f;
    public float bulletLifetime = 3f;

    //Visual variables
    protected Renderer render;
    protected Color standardColor = Color.black;
    // Start is called before the first frame update
    public virtual void Start()
    {
        initBullet();
        render = GetComponent<Renderer>();
        setColor();
        //SetBullet();
        InvokeRepeating("ShootBullet", 0f, shootSpeed);
    }

    //Initialize bullet to be unique with all the info given to the shooter
    protected void initBullet()
    {
        bullet.GetComponent<Bullet_Behavior>().lifeTime = -1;
        bullet = Instantiate(bullet); // Instantiate(bullet);
        bullet.GetComponent<Bullet_Behavior>().exclusiveTo = exclusiveTo;
        bullet.GetComponent<Bullet_Behavior>().movementSpeed = bulletMovementSpeed;
        bullet.GetComponent<Bullet_Behavior>().lifeTime = bulletLifetime;
    }

    protected void setColor()
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

    protected void SetBullet()
    {
        bullet.GetComponent<Bullet_Behavior>().exclusiveTo = exclusiveTo;
        bullet.GetComponent<Bullet_Behavior>().movementSpeed = bulletMovementSpeed;
        bullet.GetComponent<Bullet_Behavior>().lifeTime = bulletLifetime;
    }

    protected void ShootBullet()
    {
        GameObject nb =  Instantiate(bullet, transform.position, transform.rotation);
        // Destroy the bullet after x seconds of firing
        Destroy(nb, bulletLifetime);
    }

    //If Shooter becomes reactivated
    public void BeginShooting()
    {
        SetBullet(); //Make sure bullet matches shooter

        CancelInvoke("ShootBullet");        //Make sure no two invokes ever happen at the same time
        InvokeRepeating("ShootBullet", 0f, shootSpeed);
    }

    //Stop shooting bullets
    public void StopShooting()
    {
        CancelInvoke("ShootBullet");
    }

    public virtual void Deactivate()
    {
        StopShooting();
    }

    public virtual void Activate()
    {
        BeginShooting();
    }
}
