using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour
{
    bool pointing;
    // Update is called once per frame
    void Update()
    {
        print(pointing);
        if (Input.GetMouseButtonDown(0) && pointing) {
            SceneManager.LoadScene("Definitive");
        }
    }

    void OnMouseOver()
    {
        pointing = true;
    }

    void OnMouseExit()
    {
        pointing = false;
    }
}
