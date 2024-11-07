using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRoom : RoomBase1
{
    public new void SetRoomLocation(Vector3 coordinates)
    {
        
    }

    public override void OnRoomEntered()
    {
        Debug.Log("enemies are here!");
    }
}
