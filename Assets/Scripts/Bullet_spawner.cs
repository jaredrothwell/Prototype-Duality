using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_spawner : MonoBehaviour
{
    public GameObject bullet;
    public float totalTimer = 5f;
    public Transform target;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        time = totalTimer;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if( time < 0)
        {
            GameObject b = Instantiate(bullet, transform.position, Quaternion.identity);
            time = totalTimer;
            Bullet bulletScript = b.GetComponent<Bullet>();
            bulletScript.target = target;
        }
    }
}
