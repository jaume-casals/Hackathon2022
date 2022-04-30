using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLife : MonoBehaviour
{
    public GameObject BarraVida;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy") {
            BarraVida.GetComponent<ControlVida>().baixaVida();
            Destroy(col.gameObject);
        }
    }
}
