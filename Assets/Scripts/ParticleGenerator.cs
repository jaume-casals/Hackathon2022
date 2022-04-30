using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParticleGenerator : MonoBehaviour
{
    private string type = "lava";
    public GameObject sand;
    public GameObject lava;
    public GameObject storageSystem;
    public int speed = 20;
    private int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch(type) {
                case "sand":
                    GenerateParticle(sand);
                    break;
                case "lava":
                    GenerateParticle(lava);
                    break;
                default:
                    break;
            }
            
            
        }
    }

    private void GenerateParticle(GameObject particle) //tell storage particle used and place particle on mouse position
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (IsMouseOverGameWindow)
        {
            worldPosition = new Vector3(((float)(((int)(worldPosition.x*100)/8)*8)/100), ((float)(((int)(worldPosition.y*100)/8)*8)/100) , worldPosition.z);
            if (storageSystem.GetComponent<StorageSystem>().UsedBlock(particle.GetComponent<Particle>().getName()))
            {
                Instantiate(particle, worldPosition, transform.rotation);
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

    public void swaptype(string newtype) {
        type = newtype;
    }
}
