using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class laser : MonoBehaviour
{
    private LineRenderer lr;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.right, out hit))
        {
            if(hit.collider)
            {
                lr.SetPosition(1, hit.point);
                if(hit.transform.tag == "player" || hit.transform.tag == "bow")
                {
                    //hit.transform.GetComponent<Stats>().damage(1);
                    Destroy(hit.transform.gameObject);
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
            }
            else
            {
                lr.SetPosition(1, transform.right * 5000);
            }
        }
    }
}
