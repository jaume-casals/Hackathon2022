using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    private StorageSystem storageSystem;
    public enum DmgType{
        Physical, 
        Anti_Liquid,
        Anti_Fire
    };
    float blockSize;
    public float hp = 100;
    public int speed = 20;
    public float dmg = 10;
    public int coinsReward = 10;
    public DmgType dmgType = DmgType.Physical;
    private int counter = 0;

    private List<GameObject> blocksHit = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        storageSystem = GameObject.FindGameObjectWithTag("StorageSystem").GetComponent<StorageSystem>();
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
                if (!blocksHit[i].activeSelf || !blocksHit[i].GetComponent<Particle>().receiveDmg(dmg, dmgType)) //enemy dies
                    blocksHit.Remove(blocksHit[i]);
            }
        }
    }

    void Die()
    {
        storageSystem.EarnCoins(coinsReward);
        print("money?");
        Destroy(gameObject);
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
                    Die();
            }
            else //he attac
            {
                blocksHit.Add(col.gameObject);
                int dmg = col.gameObject.GetComponent<Particle>().GetDmg();
                print(dmg);
                //and he get hit
                hp = hp- dmg;
                if (hp <= 0)
                    Die();
            }
        }
        
    }
}
