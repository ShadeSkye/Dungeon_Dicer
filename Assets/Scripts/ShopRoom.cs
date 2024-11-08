using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRoom : RoomBase1
{
    public new void SetRoomLocation(Vector3 coordinates)
    {

    }

    public override void OnRoomEntered()
    {
        Debug.Log("you found a shop!");
    }

    public override void OnRoomSearched()
    {
        Debug.Log("would you like to buy anything?");
    }
}
