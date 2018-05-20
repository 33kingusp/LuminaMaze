using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    public IntSquare mazeData;
    private Random.State randomState;
    private List<Vector2Int> startList;
    private List<Vector2Int> currentWallList;

    #region Maze
    public Maze(int seed, int x, int y)
    {
        if (x <= 0) x = 1;
        if (y <= 0) y = 1;

        mazeData = new IntSquare(x * 2 + 1, y * 2 + 1);
        CreateMaze(seed);
    }
    #endregion Maze

    #region Create
    private void CreateMaze(int seed)
    {
        Random.InitState(seed);
        startList = new List<Vector2Int>();
        currentWallList = new List<Vector2Int>();

        for (int y = 0; y < mazeData.size.y; y++)
        {
            for (int x = 0; x < mazeData.size.x; x++)
            {
                if (x == 0 || y == 0 || x == mazeData.size.x - 1 || y == mazeData.size.y - 1)
                    mazeData.SetCell(x, y, 1);
                else
                    mazeData.SetCell(x, y, 0);
                if (x % 2 == 0 && y % 2 == 0)
                    startList.Add(new Vector2Int(x, y));
            }
        }

        while (startList.Count > 0)
        {
            int n = Random.Range(0, startList.Count);
            Vector2Int pos = startList[n];
            startList.RemoveAt(n);
            if (mazeData.GetCell(pos) == 0)
            {
                currentWallList.Clear();
                CreateWall(pos);
            }
        }
    }

    private void CreateWall(Vector2Int pos)
    {
        List<int> dirList = new List<int>();
        if (mazeData.GetCell(pos.x, pos.y - 1) == 0 && !isCurrentWall(pos.x, pos.y - 2))
            dirList.Add(0);
        if (mazeData.GetCell(pos.x + 1, pos.y) == 0 && !isCurrentWall(pos.x + 2, pos.y))
            dirList.Add(1);
        if (mazeData.GetCell(pos.x, pos.y + 1) == 0 && !isCurrentWall(pos.x, pos.y + 2))
            dirList.Add(2);
        if (mazeData.GetCell(pos.x - 1, pos.y) == 0 && !isCurrentWall(pos.x - 2, pos.y))
            dirList.Add(3);

        if (dirList.Count > 0)
        {
            SetWall(pos);
            bool isPath = false;
            int n = Random.Range(0, dirList.Count);
            switch (dirList[n])
            {
                case 0:
                    isPath = (mazeData.GetCell(pos.x, pos.y - 2) == 0);
                    SetWall(pos.x, pos.y--);
                    SetWall(pos.x, pos.y--);
                    break;
                case 1:
                    isPath = (mazeData.GetCell(pos.x + 2, pos.y) == 0);
                    SetWall(pos.x++, pos.y);
                    SetWall(pos.x++, pos.y);
                    break;
                case 2:
                    isPath = (mazeData.GetCell(pos.x, pos.y + 2) == 0);
                    SetWall(pos.x, pos.y++);
                    SetWall(pos.x, pos.y++);
                    break;
                case 3:
                    isPath = (mazeData.GetCell(pos.x - 2, pos.y) == 0);
                    SetWall(pos.x--, pos.y);
                    SetWall(pos.x--, pos.y);
                    break;
            }
            if (isPath) CreateWall(pos);
        }
        else
        {
            Vector2Int before = currentWallList[currentWallList.Count - 1];
            currentWallList.RemoveAt(currentWallList.Count - 1);
            CreateWall(before);
        }
    }
    #endregion Create

    #region SetWall
    private void SetWall(Vector2Int pos)
    {
        mazeData.SetCell(pos, 1);
        if (pos.x % 2 == 0 && pos.y % 2 == 0)
            currentWallList.Add(pos);
    }

    private void SetWall(int x, int y)
    {
        SetWall(new Vector2Int(x, y));
    }
    #endregion SetWall

    #region isCurrentWall
    private bool isCurrentWall(Vector2Int pos)
    {
        return (currentWallList.Contains(pos));
    }

    private bool isCurrentWall(int x, int y)
    {
        return isCurrentWall(new Vector2Int(x, y));
    }
    #endregion isCurrentWall

    public int GetRoomNumber(int x, int y)
    {
        int n = 0;
        if (mazeData.GetCell(x, y - 1) == 0) n += 1;
        if (mazeData.GetCell(x + 1, y) == 0) n += 2;
        if (mazeData.GetCell(x, y + 1) == 0) n += 4;
        if (mazeData.GetCell(x - 1, y) == 0) n += 8;
        return n;
    }
}