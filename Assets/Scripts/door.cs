using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject player = null;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "player")
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
}
