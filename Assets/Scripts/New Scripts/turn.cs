﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    public bool clockwise = true;
    private GameObject player = null;
    public float timer = 3f;
    public float currentTime = 0f;
    private Movement movement;
    public GameObject PlayerManager;
    public bool bow = true;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
        if(player != null && Input.GetButtonDown("Fire2"))
        {
            if(clockwise)
            {
                movement = PlayerManager.GetComponentInParent<Movement>();
                if (bow)
                {
                    movement.rotateBow += 90;
                    if (movement.rotateBow == 360)
                    {
                        movement.rotateBow = 0;
                    }
                }
                else
                {
                    movement.rotateShield += 90;
                    if (movement.rotateShield == 360)
                    {
                        movement.rotateShield = 0;
                    }
                }
            }
        }
        if(currentTime == 0)
        {
            currentTime = timer;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "player")
        {
            player = collider.gameObject;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "player")
        {
            player = null;
        }
    }

    private void updateTime()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0f)
        {
            currentTime = 0f;
        }
    }
}
