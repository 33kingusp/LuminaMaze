using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntSquare
{
    public Vector2Int size;
    public List<int> cell;

    #region IntSquare
    public IntSquare(int sizeX, int sizeY)
    {
        if (sizeX < 0) sizeX = 1;
        if (sizeY < 0) sizeY = 1;

        size = new Vector2Int(sizeX, sizeY);
        cell = new List<int>(new int[size.x * size.y]);
    }

    public IntSquare(int size)
    {
        new IntSquare(size, size);
    }

    public IntSquare()
    {
        new IntSquare(1);
    }
    #endregion IntSquare

    #region GetCell
    public int GetCell(int x, int y)
    {
        if (x >= size.x || y >= size.y) return 0;
        return (cell[y * size.x + x]);
    }

    public int GetCell(Vector2Int position)
    {
        return GetCell(position.x, position.y);
    }
    #endregion GetCell

    #region SetCell
    public void SetCell(int x, int y, int n)
    {
        if (x >= size.x || y >= size.y) return;
        cell[y * size.x + x] = n;
    }

    public void SetCell(Vector2Int position, int n)
    {
        SetCell(position.x, position.y, n);
    }
    #endregion GetCell

    #region Debug
    public void Debug_OutputCell()
    {
        string s = "Debug_OutputCell\n";
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
                s += GetCell(x, y).ToString();
            s += "\n";
        }
        Debug.Log(s);
    }

    public void Debug_OutputMap()
    {
        string s = "Debug_OutputMap\n";
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
                if (GetCell(x, y) == 0) s += "□";
                else s += "■";
            s += "\n";
        }
        Debug.Log(s);
    }
    #endregion Debug

}