using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParticleGenerator : MonoBehaviour
{

    public GameObject particle;
    public GameObject storageSystem;
    public int speed = 20;
    private int frameCounter = 0;
    public GameObject matrix;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("pressed_mouse");
            GenerateParticle(particle);
            
        }
    }

    private void GenerateParticle(GameObject particle) //tell storage particle used and place particle on mouse position
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (IsMouseOverGameWindow)
        {
            if (storageSystem.GetComponent<StorageSystem>().UsedBlock(particle.GetComponent<Particle>().getName()))
            {
                Vector2 matrixPos = matrix.GetComponent<matrix>().getRealPos(new Vector2(worldPosition.x, worldPosition.y), 0.08f);
                Instantiate(particle, new Vector3(matrixPos.x, matrixPos.y, worldPosition.z), transform.rotation);
            }
        }
    }

    bool IsMouseOverGameWindow 
    { 
        get 
        { 
            return !(0 > Input.mousePosition.x || 0 > Input.mousePosition.y || Screen.width < Input.mousePosition.x || Screen.height < Input.mousePosition.y); 
        } 
    }
}
