using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject dragon;
    public int SpawnRate = 20;
    private int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frameCounter++%(1000/SpawnRate) == 0) {
            GameObject z = Instantiate(zombie, transform.position, transform.rotation);
            z.SetActive(true);
            GameObject d = Instantiate(dragon, new UnityEngine.Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
            d.SetActive(true);
        }
    }
}
