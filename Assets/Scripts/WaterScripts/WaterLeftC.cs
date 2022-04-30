using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLeftC : MonoBehaviour
{
    private int collidingCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag != "enemy")
        {
            collidingCount++;
            GetComponentInParent<Particle>().IsCollidingLeft(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag != "enemy")
        {
            collidingCount--;
            GetComponentInParent<Particle>().IsCollidingLeft(false);
        }
    }
}
