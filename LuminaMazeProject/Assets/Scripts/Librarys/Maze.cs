using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze
{
    public IntSquare roomData;
    public Random.State randomState;

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
}

public static class MazeMaker
{
    private static Maze maze;


    private enum Direction
    {
        up = 0, right = 1, down = 2, left = 3,
    }

    public static Maze Make(int x, int y)
    {
        maze = new Maze(x, y);

        return maze;
    }

    private static void MakeWall()
    {

    }
}