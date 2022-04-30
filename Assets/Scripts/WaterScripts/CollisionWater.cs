using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWater : MonoBehaviour
{
    private Particle block_script;

    private int collidingCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        block_script = GetComponentInParent<Particle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            block_script.EnemyHit();
        }
        else
        {  
            collidingCount++;
            block_script.IsColliding(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (!(other.gameObject.tag == "Enemy"))
        {
            collidingCount--;
            block_script.IsColliding(false);
        }
    }
}
