using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public int heat; // 0..100 to determine how hot smth is
    public int wet; // 0..100 to determine how wet smth is
    public int density; // 0..100 to determine whether it should go up or down
    public int speed;
    public int gravity; //1 -> afecta gravetat; 0 -> no afecta gravetat; -1 -> l'afecta a l'invers

    private bool iscoll;

    private float movesize;

    // Start is called before the first frame update
    void Start()
    {
        iscoll = false;
        movesize = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (gravity == 1 && !iscoll) {
            transform.position = new Vector2(transform.position.x, transform.position.y + movesize);
        }

        else if (gravity == -1 && !iscoll) {
            transform.position = new Vector2(transform.position.x, transform.position.y - movesize);
        }
    }

    public void IsColliding(bool isColl)
    {
        iscoll = isColl;
    }
}
