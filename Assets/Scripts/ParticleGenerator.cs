using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ParticleGenerator : MonoBehaviour
{

    public GameObject particle;

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
            print("pressed_mouse");
            GenerateParticle(particle);
            
        }
    }

    private void GenerateParticle(GameObject particle)
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (IsMouseOverGameWindow)
        {
            Instantiate(particle, worldPosition, transform.rotation);
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
