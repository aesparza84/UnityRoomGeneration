using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Transform entryN, entryE, entryS, entryW;
    public bool hasN, hasE, hasS, hasW;

    private RoomsToAdd possibleRooms;

    void Start()
    {
        possibleRooms = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomsToAdd>();
        checkOpoenings();
    }


    void Update()
    {
        Debug.Log("Has N: " + hasN);
        Debug.Log("Has E: " + hasE);
        Debug.Log("Has S: " + hasS);
        Debug.Log("Has W: " + hasW);
    }

    private void checkOpoenings()
    {
        if (entryN != null)
        {
            hasN = true;
            
            GameObject n = Instantiate(possibleRooms.NorthRooms[getRandomElement(possibleRooms.NorthRooms)], entryN.position, Quaternion.identity);
        }
        if (entryE != null)
        {
            hasE = true;
        }
        if (entryS != null)
        {
            hasS = true;
        }
        if (entryW != null)
        {
            hasW = true;
        }
    }

    private int getRandomElement(GameObject[] n)
    { 
        int r = Random.Range(0, n.Length);
        return r;
    }
}
