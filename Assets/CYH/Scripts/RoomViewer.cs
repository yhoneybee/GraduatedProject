using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct RoomData
{
    public string id;
    public string name;
    public string player1;
    public string player2;
}

public class RoomViewer : MonoBehaviour
{
    RoomData roomData;
    public RoomData RoomData
    {
        get { return roomData; }
        set
        {
            roomData = value;
        }
    }
}
