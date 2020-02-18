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
        GameObject baseRoom1 = Resources.Load<GameObject>("Rooms/Base/Base room 1");
        GameObject baseRoom2 = Resources.Load<GameObject>("Rooms/Base/Base room 2");

        roomRot = Quaternion.Euler(0, 45, 0);

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                roomPos = new Vector3(((j % 2 == 0) ? 2.825f : 0) + i * 5.65f, j * 4, -j * 2.8f);

                Instantiate((Random.Range(0, 2) >= 1) ? baseRoom1 : baseRoom2, roomPos, roomRot);
                
                
                //Instantiate((Random.Range(0, 2) >= 1) ? baseRoom1 : baseRoom2, new Vector3(((j % 2 == 0) ? 2.825f : 0) + i * 5.65f, j * 4, -j * 2.8f), Quaternion.Euler(0, 0, 0));
            }
        }
    }
}