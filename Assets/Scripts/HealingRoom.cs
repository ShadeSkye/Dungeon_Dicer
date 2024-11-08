using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRoom : RoomBase1
{
    public new void SetRoomLocation(Vector3 coordinates)
    {

    }

    public override void OnRoomEntered()
    {
        Debug.Log("you found a healing room!");
    }
}
