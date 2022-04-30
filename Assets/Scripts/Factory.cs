using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{
    public Text levelText;
    private StorageSystem storageSystem;
    public string type = "sand";
    public int speed = 20;
    public int speedGain = 5;
    public int price = 10;
    public int level = 0;
    private int frameCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelText.GetComponent<Text>().text = level.ToString();
        storageSystem = GameObject.FindGameObjectWithTag("StorageSystem").GetComponent<StorageSystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (level > 0 && frameCounter++%(300/speed) == 0)
            storageSystem.ProducedBlock(type);
    }

    public void levelUp()
    {
        if (storageSystem.SpendCoins(price))
        {
            level++;
            speed += speedGain;
            levelText.GetComponent<Text>().text = level.ToString();
        }
    }
}
