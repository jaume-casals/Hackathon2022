using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public enum DmgType{
        Physical, 
        Anti_Liquid,
        Anti_Fire
    };
    float blockSize;
    public float hp = 100;
    public int speed = 20;
    public float dmg = 10;

    public DmgType dmgType = DmgType.Physical;
    private int counter = 0;

    private List<GameObject> blocksHit = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        blockSize = GameObject.FindGameObjectWithTag("Block").GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter++%(300/speed) == 0)
        {
            transform.position = new Vector2(transform.position.x-blockSize, transform.position.y);
            for (int i = 0; i < blocksHit.Count; ++i)
            {
                if (!blocksHit[i].GetComponent<Particle>().receiveDmg(dmg, dmgType)) //enemy dies
                    blocksHit.Remove(blocksHit[i]);
            }
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Block")
        {
            float fallDmg = col.gameObject.GetComponent<Particle>().FallHitDmg();
            if (fallDmg > 0) //we receive dmg
            {
                hp = hp - col.gameObject.GetComponent<Particle>().FallHitDmg();
                print("dmg =" + col.gameObject.GetComponent<Particle>().FallHitDmg());
                print("hp =" + hp);
                if (hp < 0)
                    Destroy(gameObject);
            }
            else //he attac
            {
                blocksHit.Add(col.gameObject);
            }
        }
        
    }
}
