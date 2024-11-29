using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : RoomBase1
{
    public new void SetRoomLocation(Vector3 coordinates)
    {

    }

    public override void OnRoomEntered()
    {
        Debug.Log("you find yourself in a mysterious dungeon");
    }
}
