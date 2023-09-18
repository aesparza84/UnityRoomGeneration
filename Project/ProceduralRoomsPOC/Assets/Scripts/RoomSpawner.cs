using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Transform entryN, entryE, entryS, entryW;
    public bool hasN, hasE, hasS, hasW;
    static int ID;

    private RoomsToAdd possibleRooms;
    public bool functionedCalled =false;

    [SerializeField] private int maxRoomCount;
    

    void Start()
    {
        ID++;
        Debug.Log("ID: "+ID+" instantiated");
        possibleRooms = GameObject.FindGameObjectWithTag("RoomRefernces").GetComponent<RoomsToAdd>();
        Invoke("checkOpoenings", 1.0f);
    }

    private void checkOpoenings()
    {
        if (RoomManager.spawnedRooms < RoomManager.minRooms && !functionedCalled)
        {
            if (entryN != null)
            {
                hasN = true;
                GameObject n = Instantiate(possibleRooms.NorthRooms[getRandomElement(possibleRooms.NorthRooms)], entryN.position, Quaternion.identity);
                RoomManager.addRoom(n);
            }
            if (entryE != null)
            {
                hasE = true;
                GameObject n = Instantiate(possibleRooms.EastRooms[getRandomElement(possibleRooms.EastRooms)], entryE.position, Quaternion.identity);
                RoomManager.addRoom(n);
            }
            if (entryS != null)
            {
                hasS = true;
                GameObject n = Instantiate(possibleRooms.SouthRooms[getRandomElement(possibleRooms.SouthRooms)], entryS.position, Quaternion.identity);
                RoomManager.addRoom(n);
            }
            if (entryW != null)
            {
                hasW = true;
                GameObject n = Instantiate(possibleRooms.WestRooms[getRandomElement(possibleRooms.WestRooms)], entryW.position, Quaternion.identity);
                RoomManager.addRoom(n);
            }
        }

        //Closes off any openings after desired room count is reached
        if (RoomManager.spawnedRooms >= RoomManager.minRooms)
        {
            if (entryN != null)
            {
                GameObject n = Instantiate(possibleRooms.ClosingNorth, entryN.position, Quaternion.identity);
                RoomManager.addRoom(n);
            }
            if (entryE != null)
            {
                GameObject n = Instantiate(possibleRooms.ClosingEast, entryE.position, Quaternion.identity);
                RoomManager.addRoom(n);

            }
            if (entryS != null)
            {
                GameObject n = Instantiate(possibleRooms.ClosingSouth, entryS.position, Quaternion.identity);
                RoomManager.addRoom(n);
            }
            if (entryW != null)
            {
                GameObject n = Instantiate(possibleRooms.ClosingWest, entryW.position, Quaternion.identity);
                RoomManager.addRoom(n);
            }
        }
        functionedCalled = true;
        Debug.Log("Done");

    }

    private int getRandomElement(GameObject[] n)
    { 
        int r = Random.Range(0, n.Length);
        return r;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //check if other entrypoints are collding with the Center

        Debug.Log(coll.gameObject.name+" is whats detected; from "+gameObject.name);
        if (coll != null)
        {
            Destroy(coll.gameObject);
        }
        
        
    }
}
