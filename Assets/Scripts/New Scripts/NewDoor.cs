using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    public GameObject trigger1;
    public GameObject trigger2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(trigger1.GetComponent<trigger>().player != null && trigger2.GetComponent<trigger>().player != null)
        {
            Destroy(gameObject);
        }
    }
}
