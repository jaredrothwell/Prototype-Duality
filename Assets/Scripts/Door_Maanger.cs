using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Maanger : MonoBehaviour
{
    public string NextLevel;
    public door door1;
    public door door2;

    // Update is called once per frame
    void Update()
    {
        if(door1.player != null && door2.player != null)
        {
            SceneManager.LoadScene(NextLevel);
        }
    }
}
