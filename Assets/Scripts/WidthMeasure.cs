using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthMeasure : MonoBehaviour
{
    // Start is called before the first frame update
    int counter = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + gameObject.GetComponent<SpriteRenderer>().bounds.size.x, transform.position.y);
        print(counter++);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (counter > 20)
            Destroy(gameObject);


    }
}
