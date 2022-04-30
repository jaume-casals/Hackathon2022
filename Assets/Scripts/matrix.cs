using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matrix : MonoBehaviour
{
    public GameObject sandBlock;
    int sizeY = 50;
    int sizeX = 165;
    public string[,] map;
    public Vector2 iniPos;
    public float block_size;

  // Start is called before the first frame update
    void Start()
    {
        map = new string[sizeX, sizeY];
        for (int i = 0; i < sizeX; ++i) {
            for (int j = 0; j < sizeY; ++j) map[i, j] = "empty";
        }
        //for (int i = 0; i < size; ++i) map[i, 1] = "a";
        iniPos = new Vector2(-4, -3);
        
        block_size = sandBlock.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    public void setPos(Vector2 pos, string type) {
        map[(int) ((pos.x - iniPos.x) / block_size), (int) ((pos.y - iniPos.y) / block_size)] = type;
    }

    public Vector2 getPos(Vector2 pos) {
        return new Vector2 ((int) ((pos.x - iniPos.x) / block_size), (int) ((pos.y - iniPos.y) / block_size));
    }

    //returns -1 if the nearest hole is left, if it is right, 0 if there's no hole
    public int searchNearbyHoleDownwards(Vector2 pos) {
        int x = (int) ((pos.x - iniPos.x) / block_size);
        int y = (int) ((pos.y - iniPos.y) / block_size);
        if (y == 0) return 0;
        int left, right;
        left = x - 1;
        right = x + 1;

        while (left >= 0 && right < sizeX) {
            if (map[left, y - 1] == "empty") return -1;
            if (map[right, y - 1] == "empty") return 1;
            right++;
            left--;
        }

        while (left >= 0) {
            if (map[left, y - 1] == "empty") return -1;
            left--;
        }
        while (right < sizeX) {
            if (map[right, y - 1] == "empty") return 1;
            right++;
        }

        return 0;
    }

    public int searchNearbyHoleUpwards(Vector2 pos) {
        int x = (int) ((pos.x - iniPos.x) / block_size);
        int y = (int) ((pos.y - iniPos.y) / block_size);
        if (y == sizeY - 1) return 0;
        int left, right;
        left = x - 1;
        right = x + 1;

        while (left >= 0 && right < sizeX) {
            if (map[left, y + 1] == "empty") return -1;
            if (map[right, y + 1] == "empty") return 1;
            right++;
            left--;
        }

        while (left >= 0) {
            if (map[left, y + 1] == "empty") return -1;
            left--;
        }
        while (right < sizeX) {
            if (map[right, y + 1] == "empty") return 1;
            right++;
        }

        return 0;
    }

    public Vector2 getRealPos(Vector2 pos, float szbl) {
        Vector2 norm = new Vector2((int) ((pos.x - iniPos.x) / szbl), (int) ((pos.y - iniPos.y) / szbl));
        return new Vector2(norm.x * szbl, norm.y * szbl);
    }
}
