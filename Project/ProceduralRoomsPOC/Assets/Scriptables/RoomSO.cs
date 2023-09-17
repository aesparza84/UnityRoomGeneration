using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Room", menuName ="New Room")]
public class RoomSO : ScriptableObject
{
    public string Name;
    public GameObject[] roomPrefab;
    public bool isBossRoom;
    public bool isUtilRoom;
}
