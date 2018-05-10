using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] List<GameObject> doorObject;

    public void OpenDoor(int roomNumber)
    {
        if (roomNumber < 0 || roomNumber >= 16) roomNumber = 0;
        for(int n = 3; n >= 0; n--)
        {
            int b = (int)Mathf.Pow(2, n);
            if (roomNumber >= b)
            {
                roomNumber %= b;
                doorObject[n].SetActive(false);
            }
            else
                doorObject[n].SetActive(true);
        }
    }
}
