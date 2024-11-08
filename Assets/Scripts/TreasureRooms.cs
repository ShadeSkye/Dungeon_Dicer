using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRooms : RoomBase1
{
    public new void SetRoomLocation(Vector3 coordinates)
    {

    }

    public override void OnRoomEntered()
    {
        Debug.Log("theres lots of treasure in here!");
    }

    public override void OnRoomSearched()
    {
        int randomInt = Random.Range(10, 50);
        Debug.Log($"you found { randomInt } gold coins!");
    }
}
