using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct RoomData
{
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
            txtName.text = roomData.name.ToString();
            txtPlayers.text = $"{roomData.player1}, {roomData.player2}";
            roomData = value;
        }
    }

    public Text txtName;
    public Text txtPlayers;
}
