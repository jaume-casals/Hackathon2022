using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSandGenerator : MonoBehaviour
{
    public GameObject SandBlock;
    public float space = 0;

    // Start is called before the first frame update
    void Start()
    {
        space = SandBlock.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(SandBlock, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2 (transform.position.x-space, transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2 (transform.position.x+space, transform.position.y);
        }
    }
}
