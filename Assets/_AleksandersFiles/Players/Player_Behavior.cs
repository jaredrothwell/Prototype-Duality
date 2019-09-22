using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behavior : MonoBehaviour
{
    public Vector3 respawnLocation;
    private int numOfDeaths = 0;
    // Start is called before the first frame update
    void Start()
    {
        respawnLocation = this.transform.position;
    }

    public void Death()
    {
        Debug.Log("PlayerDied");
        this.transform.position = respawnLocation;
        numOfDeaths++;

        //Enable input
    }
}
