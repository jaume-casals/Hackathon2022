using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public int speed = 20;
    private int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frameCounter++%(1000/speed) == 0)
            Instantiate(zombie, transform.position, transform.rotation);
    }
}
