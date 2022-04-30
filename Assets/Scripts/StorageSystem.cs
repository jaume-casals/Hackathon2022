using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageSystem : MonoBehaviour
{
    public Text sandcountertest;
    public Text coinsText;
    private int sandBlocks = 0;

    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        coinsText.GetComponent<Text>().text = coins.ToString();

        sandBlocks = 1000;
        sandcountertest.GetComponent<Text>().text = sandBlocks.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SpendCoins (int coins) 
    {
        if (coins <= this.coins)
        {
            this.coins -= coins;
            coinsText.GetComponent<Text>().text = this.coins.ToString();
            return true;
        }
        return false;
    }

    public void EarnCoins(int coins)
    {
        this.coins += coins;
        coinsText.GetComponent<Text>().text = this.coins.ToString();
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

    public void ProducedBlock(string type)
    {
        switch(type)
        {
            case "sand":
                sandBlocks++;
                sandcountertest.GetComponent<Text>().text = sandBlocks.ToString();
                break;
            default:
                break;
        }
    }
}
