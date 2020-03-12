using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGenerator : MonoBehaviour
{
    Vector3 roomPos;
    Quaternion roomRot;

    void Start()
    {
        GenerateRooms();
    }

    void GenerateRooms()
    {
        // Test rooms
        GameObject baseRoom = Resources.Load<GameObject>("Rooms/Base room");
        GameObject sellRoom = Resources.Load<GameObject>("Rooms/Sell room");
        GameObject commerceRoom = Resources.Load<GameObject>("Rooms/Commerce room");

        roomRot = Quaternion.Euler(0, 135, 0);

        for (int i = -5; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                roomPos = new Vector3(((j % 2 == 0) ? 9 : 0) + i * 18, j * 12.8f, -j * 9);

                if (i == 0 && j == 3)
                {

                    Instantiate(baseRoom, roomPos, roomRot);
                }
                else Instantiate((Random.Range(0, 2) >= 1) ? baseRoom : ((Random.Range(0, 2) >= 1) ? sellRoom : commerceRoom), roomPos, roomRot);
            }
        }
    }
}