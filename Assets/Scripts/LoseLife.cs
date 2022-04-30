using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseLife : MonoBehaviour
{
    public GameObject BarraVida;
    private long counter;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.002f * (float) Math.Sin(counter/100.0f));
        ++counter;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy") {
            BarraVida.GetComponent<ControlVida>().baixaVida();
            Destroy(col.gameObject);
        }
    }
}
