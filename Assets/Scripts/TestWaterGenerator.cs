using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWaterGenerator : MonoBehaviour
{
    public GameObject WaterBlock;
    public float space = 0;

    // Start is called before the first frame update
    void Start()
    {
        space = WaterBlock.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(WaterBlock, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector2 (transform.position.x-space, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector2 (transform.position.x+space, transform.position.y);
        }
    }
}
