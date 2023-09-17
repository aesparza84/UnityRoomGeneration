using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public Transform entryN, entryE, entryS, entryW;
    public bool hasN, hasE, hasS, hasW;

    private RoomsToAdd possibleRooms;
    public bool hasSpawnedRooms =false;
    static int spawnedRooms = 0;

    void Start()
    {
        possibleRooms = GameObject.FindGameObjectWithTag("RoomRefernces").GetComponent<RoomsToAdd>();
        Invoke("checkOpoenings", 1.5f);
        //checkOpoenings();
    }


    void Update()
    {
        //Debug.Log("Has N: " + hasN);
        //Debug.Log("Has E: " + hasE);
        //Debug.Log("Has S: " + hasS);
        //Debug.Log("Has W: " + hasW);
        Debug.Log("Room count: "+spawnedRooms);
    }

    private void checkOpoenings()
    {
        if (spawnedRooms < 4 && !hasSpawnedRooms)
        {
            if (entryN != null)
            {
                hasN = true;

                GameObject n = Instantiate(possibleRooms.NorthRooms[getRandomElement(possibleRooms.NorthRooms)], entryN.position, Quaternion.identity);
            }
            if (entryE != null)
            {
                hasE = true;
                GameObject n = Instantiate(possibleRooms.EastRooms[getRandomElement(possibleRooms.EastRooms)], entryE.position, Quaternion.identity);
            }
            if (entryS != null)
            {
                hasS = true;
                GameObject n = Instantiate(possibleRooms.SouthRooms[getRandomElement(possibleRooms.SouthRooms)], entryS.position, Quaternion.identity);
            }
            if (entryW != null)
            {
                hasW = true;
                GameObject n = Instantiate(possibleRooms.WestRooms[getRandomElement(possibleRooms.WestRooms)], entryW.position, Quaternion.identity);
            }
            spawnedRooms++;
            hasSpawnedRooms = true;
        }
        
    }

    private int getRandomElement(GameObject[] n)
    { 
        int r = Random.Range(0, n.Length);
        return r;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log(gameObject.name +" is hitting "+coll.name);
        if (coll != null)
        {
            RoomSpawner s = coll.GetComponent<RoomSpawner>();
            s.hasSpawnedRooms = true;
        }
    }
}
