using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public bool link = true;
    public float fadeSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
            link = !link;

        if (link)
        {
            Color color = this.GetComponent<MeshRenderer>().material.color;
            color.a = 1.0f;
            this.GetComponent<MeshRenderer>().material.color = color;
            this.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            Color color = this.GetComponent<MeshRenderer>().material.color;
            color.a = 0.20f;
            this.GetComponent<MeshRenderer>().material.color = color;
            this.GetComponent<BoxCollider>().enabled = false;
        }
            
    }
}
