using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    private Random.State randomState;
    private Vector2Int size;
    private List<int> map;

    public Maze(int x, int y)
    {
        if (x < 1) x = 1;
        if (y < 1) y = 1;

        size.x = x;
        size.y = y;
        map = new List<int>(new int[size.x * size.y]);
        randomState = Random.state;
    }

    public void MakeMaze(int seed)
    {
        int x = size.x* 2 + 1;
        int y = size.y * 2 + 1;
        List<int> w = new List<int>(new int[x * y]);
        Random.InitState(seed);

        for (int m = 0; m < y; m++)
            for (int n = 0; n < y; n++)
                if (n == 0 || n == x - 1 || m == 0 || m == y - 1)
                    w[m * x + n] = 1;

        while (true)
        {
            List<Vector2Int> stack = new List<Vector2Int>();



            break;
        }

        randomState = Random.state;
        DebugRoom(w);
    }


    private void DebugRoom(List<int> w)
    {
        int x = size.x * 2 + 1;
        int y = size.y * 2 + 1;
        string s = "";
        for (int m = 0; m < y; m++)
        {
            for (int n = 0; n < y; n++)
            {
                s += w[m * x + n].ToString() + " ";
            }
            s += "\n";
        }
        Debug.Log(s);
    }
}