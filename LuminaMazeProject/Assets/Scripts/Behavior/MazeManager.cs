using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] GameObject roomPrefab;

    private void Start()
    {
        Maze m = new Maze(999, 5, 5);
        m.mazeData.Debug_OutputMap();
        InstantiateMap(m);
    }

    public void InstantiateMap(Maze maze)
    {
        IntSquare mazeData = maze.mazeData;
        for (int y = 1; y < mazeData.size.y; y += 2)
        {
            for (int x = 1; x < mazeData.size.x; x += 2)
            {
                GameObject room = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity, transform);
                room.GetComponent<Room>().OpenDoor(maze.GetRoomNumber(x, y));
                room.transform.position = new Vector3(x * 5, 0, -y * 5);
            }
        }
    }
}
