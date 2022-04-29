using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    float blockSize;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        blockSize = GameObject.FindGameObjectWithTag("Block").GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter++%30 == 0)
            transform.position = new Vector2(transform.position.x-blockSize, transform.position.y);
    }
}
