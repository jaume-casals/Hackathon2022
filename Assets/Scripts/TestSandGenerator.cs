using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSandGenerator : MonoBehaviour
{
    public GameObject SandBlock;
    public float space = 0;
    public GameObject MatrixGameObject;

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
            Vector2 pos = MatrixGameObject.GetComponent<matrix>().getRealPos(transform.position, 0.08f);
            Instantiate(SandBlock, pos, transform.rotation);
            SandBlock.GetComponent<Particle>().MatrixGameObject = MatrixGameObject;
            SandBlock.GetComponent<Particle>().isSand = true;
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
