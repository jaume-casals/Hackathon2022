using UnityEngine;

public class Particle : MonoBehaviour
{
    public GameObject MatrixGameObject;
    private matrix mat;

    public new string name = "sand"; //name in lower case
    public int health = 100; //100 base, can be modified
    public int heat = 0; // 0..100 to determine how hot smth is
    public int wet = 0; // 0..100 to determine how wet smth is
    public int density = 75; // 0..100 to determine whether it should go up or down
    public int speed; //how fast it falls TO DO
    public int gravity = -1; //1 -> afecta gravetat a l'invers; 0 -> no afecta gravetat; -1 -> l'afecta la gravetat
    public int damage = 0; //0..100 -> contact dmg
    public bool isFluid = false;
    private float fallDmgFactor; //0..5 -> multiplies the fall dmg when it falls on an enemy
    private bool iscoll;
    private bool iscollRight;
    private bool iscollLeft;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (dieInPeace)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        Vector2 originalPos = transform.position;
        if (gravity == 1 && !iscoll) { //falling up
            transform.position = new Vector2(transform.position.x, transform.position.y + movesize);
        }

        if (gravity == -1 && !iscoll) { //falling down
            transform.position = new Vector2(transform.position.x, transform.position.y - movesize);
            fallenBlocks++;
        }
        else if (isFluid && gravity == -1 && iscoll)
        {
            print("moving to the side");
            int select = Random.Range(0,2);
            if (select == 0)
            {
                if (!iscollLeft)
                    transform.position = new Vector2(transform.position.x - movesize, transform.position.y);
            }
            else
            {
                if (!iscollRight)
                    transform.position = new Vector2(transform.position.x + movesize, transform.position.y);
            }
        }

        if (transform.position.x < -5.5f || transform.position.x > 6f)
        {
            transform.position = new Vector2(originalPos.x, transform.position.y);
        }
        
        if (transform.position.y < -3.2f)
        {
            transform.position = new Vector2(transform.position.x, originalPos.y);
            iscoll = true;
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
    }

    public void IsCollidingRight(bool iscollRight)
    {
        this.iscollRight = iscollRight;
    }

    public void IsCollidingLeft (bool iscollLeft)
    {
        this.iscollLeft = iscollLeft;
    }

    public void EnemyHit()
    {
        enemyHit = true;
    }
    public int GetDmg()
    {
        return damage;
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
