using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    private IntSquare roomData;
    private Random.State randomState;

    #region Maze
    public Maze(int x, int y)
    {
        roomData = new IntSquare(x, y);

        randomState = Random.state;
    }

    public Maze()
    {
        new Maze(1, 1);
    }
    #endregion Maze

    public void MakeMaze(int seed)
    {
        IntSquare map = new IntSquare(roomData.size.x * 2 + 1, roomData.size.y * 2 + 1);
        List<Vector2Int> start = new List<Vector2Int>();
        Random.InitState(seed);

        for (int y = 0; y < map.size.y; y++)
            for (int x = 0; x < map.size.x; x++)
            {
                if (x == 0 || x == map.size.x - 1 || y == 0 || y == map.size.y - 1)
                    map.SetCell(x, y, 1);
                else if (x % 2 == 0 && y % 2 == 0)
                    start.Add(new Vector2Int(x, y));
            }

        for (int n = 0; n < start.Count; n++)
        {
            Vector2Int pos = start[Random.Range(0,start.Count)];
            
        }

        map.Debug_OutputCell();

        randomState = Random.state;
    }
}