using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] GameObject roomPrefab;

    private void Start()
    {
        Maze m = new Maze(5, 5);
        m.MakeMaze(0);
    }

    public void InstantiateMap()
    {
    }
}
