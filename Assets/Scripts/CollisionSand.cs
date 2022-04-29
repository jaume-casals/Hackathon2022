using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSand : MonoBehaviour
{
    private Particle block_script;
    // Start is called before the first frame update
    void Start()
    {
        block_script = GetComponentInParent<Particle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        block_script.IsColliding(true);
    }
}
