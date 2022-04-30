using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matrix : MonoBehaviour
{
    int sizeY = 50;
    int sizeX = 165;
    public string[,] map;
    public Vector2 iniPos;

  // Start is called before the first frame update
    void Start()
    {
        map = new string[sizeY, sizeX];
        for (int i = 0; i < sizeX; ++i) {
            for (int j = 0; j < sizeY; ++j) map[i, j] = "empty";
        }
        //for (int i = 0; i < size; ++i) map[i, 1] = "a";
        iniPos = new Vector2(-4, -3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    public void setPos(Vector2 pos, float size_blockX, float size_blockY, string type) {
        map[(int) (size_blockX * (pos.x - iniPos.x)), (int) (size_blockY * (pos.y - iniPos.y))] = type;
    }

    //returns -1 if the nearest hole is left, if it is right, 0 if there's no hole
    public int searchNearbyHoleDownwards(int x, int y) {
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

    public int searchNearbyHoleUpwards(int x, int y) {
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

    public Vector2 getRealPos(Vector2 pos, float size_blockX, float size_blockY) {
        return new Vector2((int) (size_blockX * (pos.x - iniPos.x)), (int) (size_blockY * (pos.y - iniPos.y)));
    }
}
