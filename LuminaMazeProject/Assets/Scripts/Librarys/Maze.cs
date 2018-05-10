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
        Vector2Int s = new Vector2Int(size.x * 2 + 1, size.y * 2 + 1);
        List<Vector2Int> start = new List<Vector2Int>();
        List<int> w = new List<int>(new int[s.x * s.y]);
        Random.InitState(seed);

        for (int y = 0; y < s.y; y++)
            for (int x = 0; x < s.x; x++)
            {
                if (x == 0 || x == s.x - 1 || y == 0 || y == s.y - 1)
                    w[y * s.x + x] = 1;
                else if (x % 2 == 0 && y % 2 == 0)
                    start.Add(new Vector2Int(x, y));
            }

        for (int n = 0; n < start.Count; n++)
        {
            List<Vector2Int> stack = new List<Vector2Int>();
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