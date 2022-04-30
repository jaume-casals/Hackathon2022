using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject dragon;
    public GameObject police;
    public int SpawnRate = 20;
    private int frameCounter = 0;
    // Start is called before the first frame update
    private int frameCounterCounter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (frameCounter++%(2000/SpawnRate) == 0) {
            ++frameCounterCounter;
            if (frameCounterCounter%4 == 0) {
                GameObject p = Instantiate(police, transform.position, transform.rotation);
                p.SetActive(true);
            }
            else {
                GameObject z = Instantiate(zombie, transform.position, transform.rotation);
                z.SetActive(true);
            }

            if (frameCounterCounter%8 == 0) {
                GameObject d = Instantiate(dragon, new UnityEngine.Vector3(transform.position.x, transform.position.y + 3, transform.position.z), transform.rotation);
                d.SetActive(true);
            }
        }
    }
}
