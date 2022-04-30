using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class matrix : MonoBehaviour
{
    int size = 50;
    public string[,] map;

    // Start is called before the first frame update
    void Start()
    {
        map = new string[size, size];
        for (int i = 0; i < size; ++i) {
            for (int j = 0; j < size; ++j) map[i, j] = "empty";
        }
        //for (int i = 0; i < size; ++i) map[i, 1] = "a";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    public void setPos(int x, int y, string type) {
        map[x, y] = type;
    }

    //returns -1 if the nearest hole is left, if it is right, 0 if there's no hole
    public int searchNearbyHoleDownwards(int x, int y) {
        if (y == 0) return 0;
        int left, right;
        left = x - 1;
        right = x + 1;

        while (left >= 0 && right < size) {
            if (map[left, y - 1] == "empty") return -1;
            if (map[right, y - 1] == "empty") return 1;
            right++;
            left--;
        }

        while (left >= 0) {
            if (map[left, y - 1] == "empty") return -1;
            left--;
        }
        while (right < size) {
            if (map[right, y - 1] == "empty") return 1;
            right++;
        }

        return 0;
    }

    public int searchNearbyHoleUpwards(int x, int y) {
        if (y == 49) return 0;
        int left, right;
        left = x - 1;
        right = x + 1;

        while (left >= 0 && right < size) {
            if (map[left, y + 1] == "empty") return -1;
            if (map[right, y + 1] == "empty") return 1;
            right++;
            left--;
        }

        while (left >= 0) {
            if (map[left, y + 1] == "empty") return -1;
            left--;
        }
        while (right < size) {
            if (map[right, y + 1] == "empty") return 1;
            right++;
        }

        return 0;
    }
}
