using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGenerator : MonoBehaviour
{
    List<Room> rooms;

    public static string[] RoomTypes;

    class Room
    {
        public string Type;
        public Vector3 Pos;

        public Room(Vector3 pos, string type)
        {
            Pos = pos;
            Type = type;
            Instantiate(Resources.Load<GameObject>("Rooms/" + type), pos, Quaternion.Euler(0, 0, 0));
        }

        public Room(Vector3 pos)
        {
            Pos = pos;
            Type = RoomTypes[Random.Range(4, 6)];
            Instantiate(Resources.Load<GameObject>("Rooms/" + Type), pos, Quaternion.Euler(0, 0, 0));
        }
    }

    void Start()
    {
        rooms = new List<Room>();
        RoomTypes = new string[6];
        RoomTypes[0] = "First room";
        RoomTypes[1] = "Base room";
        RoomTypes[2] = "Sell room";
        RoomTypes[3] = "Commerce room";
        RoomTypes[4] = "Forest room";
        RoomTypes[5] = "Rocks room";
        GenerateRooms();
    }

    void GenerateRooms()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == 0)
            {
                Room firstRoom = new Room(new Vector3(i * 13, 0, - 13 - i * 13), RoomTypes[0]); // First room ever
                rooms.Add(firstRoom);
                rooms.Add(new Room(new Vector3(i * 13, -13, - 26 - i * 13)));
            }
            else
            {
                Room firstRoom = new Room(new Vector3(i * 13, 0, - 13 - i * 13), RoomTypes[Random.Range(1, 4)]);
                rooms.Add(firstRoom);
                rooms.Add(new Room(new Vector3(i * 13, -13, - 26 - i * 13)));
            }

            Room secondRoom = new Room(new Vector3(-13 + i * 13, -26, -26 - i * 13), RoomTypes[Random.Range(1, 4)]);
            rooms.Add(secondRoom);
            rooms.Add(new Room(new Vector3(-13 + i * 13, -39, -39 - i * 13)));

            Room thirdRoom = new Room(new Vector3(-26 + i * 13, -52, -39 - i * 13), RoomTypes[Random.Range(1, 4)]);
            rooms.Add(thirdRoom);
            rooms.Add(new Room(new Vector3(-26 + i * 13, -65, -52 - i * 13)));
        }
    }
}