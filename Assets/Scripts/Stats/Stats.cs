﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int Health = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
            Destroy(gameObject);
    }

    public void damage(int dmg)
    {
        Health -= dmg;
        if (Health < 0)
            Health = 0;
    }
}
