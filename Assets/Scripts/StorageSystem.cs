using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageSystem : MonoBehaviour
{
    public Text sandcountertest;
    public Text lavacountertest;
    public Text stonecountertest;
    public Text coinsText;
    private int sandBlocks = 0;
    private int lavaBlocks = 0;
    private int stoneBlocks = 0;

    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        coinsText.GetComponent<Text>().text = coins.ToString();

        sandBlocks = 8;
        lavaBlocks = 0;
        stoneBlocks = 0;
        sandcountertest.GetComponent<Text>().text = sandBlocks.ToString();
        lavacountertest.GetComponent<Text>().text = lavaBlocks.ToString();
        stonecountertest.GetComponent<Text>().text = stoneBlocks.ToString();
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
            case "lava":
                if (lavaBlocks <= 0)
                    return false;
                lavaBlocks--;
                lavacountertest.GetComponent<Text>().text = lavaBlocks.ToString();
                break;
            case "stone":
                if (stoneBlocks <= 0)
                    return false;
                stoneBlocks--;
                stonecountertest.GetComponent<Text>().text = stoneBlocks.ToString();
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
            case "lava":
                lavaBlocks++;
                lavacountertest.GetComponent<Text>().text = lavaBlocks.ToString();
                break;
            case "stone":
                stoneBlocks++;
                stonecountertest.GetComponent<Text>().text = stoneBlocks.ToString();
                break;
            default:
                break;
        }
    }
}
