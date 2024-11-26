using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoom : RoomBase1
{
    [SerializeField] GameObject LadderText;

    public new void SetRoomLocation(Vector3 coordinates)
    {

    }

    public override void OnRoomEntered()
    {
        Debug.Log("you found the exit!");
        LadderText.SetActive(true);
        UIManager.PlayerCanLeave = true;
    }

    public override void OnRoomExited()
    {
        LadderText.SetActive(false);
        UIManager.PlayerCanLeave = false;
    }

    public override void OnRoomSearched()
    {
        Debug.Log("would you like to leave?");
    }
}
