using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject MatrixGameObject;
    private matrix mat;

    public string name = "sand"; //name in lower case
    public int health = 100; //100 base, can be modified
    public int heat = 0; // 0..100 to determine how hot smth is
    public int wet = 0; // 0..100 to determine how wet smth is
    public int density = 75; // 0..100 to determine whether it should go up or down
    public int speed; //how fast it falls TO DO
    public int gravity = 1; //1 -> afecta gravetat a l'invers; 0 -> no afecta gravetat; -1 -> l'afecta la gravetat
    public int damage = 0; //0..100 -> contact dmg
    public bool isFluid = false;
    public bool isSand = false;
    private float fallDmgFactor; //0..5 -> multiplies the fall dmg when it falls on an enemy
    private bool iscoll;
    private float movesize;
    private int fallenBlocks = 0;
    private bool enemyHit = false;
    private bool dieInPeace = false;
 
    // Start is called before the first frame update 
    void Start()
    {
        fallDmgFactor = Mathf.Max(0,5*((float)(density-50)/50f)); // de 0 a 5 en funcio de la densitat
        iscoll = false;
        movesize = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
        mat = MatrixGameObject.GetComponent<matrix>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dieInPeace)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (gravity == 1 && !iscoll) { //falling up
            transform.position = new Vector2(transform.position.x, transform.position.y + movesize);
        }

        if (gravity == -1 && !iscoll) { //falling down
            mat.setPos(transform.position, "empty");
            transform.position = new Vector2(transform.position.x, transform.position.y - movesize);
            //transform.position = mat.getRealPos(new Vector2(transform.position.x, transform.position.y - movesize), movesize);
            mat.setPos(transform.position, "sand");
            fallenBlocks++;
        }
    }

    public string getName()
    {
        return name;
    }

    public void IsColliding(bool isColl)
    {
        //Si es aigua si que pot caure

        iscoll = isColl;
        fallenBlocks = 0;

        int dir = 0;
        //if (isFluid && gravity == -1) dir = mat.searchNearbyHoleDownwards(transform.position);
        if (isFluid && gravity == 1) dir = mat.searchNearbyHoleUpwards(transform.position);

       
        if (isSand) dir = mat.searchSandHole(transform.position);
        
        
        if (dir != 0)
        {
            if (isSand) mat.setPos(transform.position, "empty");
            transform.position = new Vector2(transform.position.x + dir*movesize, transform.position.y);
            if (isSand) mat.setPos(transform.position, "sand");
            if (mat.DownIsEmpty(transform.position))
                iscoll = false;
        }
    }

    public void EnemyHit()
    {
        enemyHit = true;
    }

    public float FallHitDmg()
    {
        float dmg = fallenBlocks*fallDmgFactor;
        if (enemyHit && dmg > 0)
        {
            dieInPeace = true;
        }
        return (fallenBlocks*fallDmgFactor);
    }

    /**Returns true if the particle lives and false if it dies
    */
    public bool receiveDmg(float dmg, EnemyBasic.DmgType dmgType)
    {
        if (wet ==  0 && heat == 0 && dmgType == EnemyBasic.DmgType.Physical)
            health = health - (int)dmg;
        if (health < 0)
        {
            dieInPeace = true;
            return false;
        }
        else return true;
    }

}
