using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageSystem : MonoBehaviour
{
    public Text sandcountertest;
    private int sandBlocks = 0;

    private int money = 0;
    // Start is called before the first frame update
    void Start()
    {
        sandBlocks = 10;
        sandcountertest.GetComponent<Text>().text = sandBlocks.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**Returns true if there are blocks left and false if not
    */
    public bool UsedBlock(string type)
    {
        switch(type)
        {
            case "sand":
                if (sandBlocks <= 0)
                    return false;
                sandBlocks--;
                sandcountertest.GetComponent<Text>().text = sandBlocks.ToString();
                break;
            default:
                break;
        }
        
        return true;
    }
}
