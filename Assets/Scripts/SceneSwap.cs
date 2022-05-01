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
        print(Input.GetMouseButtonDown(0));
        if (Input.GetMouseButtonDown(0) && pointing) {
            SceneManager.LoadScene("REAL_DEF");
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
