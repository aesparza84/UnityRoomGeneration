using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<GameObject> roomList;
    private static List<GameObject> RoomList;

    private RoomsToAdd r;

    public static int spawnedRooms = 0;
    public static int minRooms = 11;
    void Start()
    {
        r = GameObject.FindGameObjectWithTag("RoomRefernces").GetComponent<RoomsToAdd>();
        roomList = new List<GameObject>();
        GameObject startRoom = Instantiate(r.SouthRooms[1], new Vector3(7.0f, 4.0f, 0.0f), Quaternion.identity);
        addRoom(startRoom);
    }

    void Update()
    {
        RoomManager.RoomList = roomList;
    }

    public static void addRoom(GameObject n)
    { 
        RoomList.Add(n);
        spawnedRooms++;
    }
}
