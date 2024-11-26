using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBase1 : MonoBehaviour
{
    private RoomBase1 _north, _east, _south, _west;

    public RoomBase1 North => _north;
    public RoomBase1 East => _east;
    public RoomBase1 South => _south;
    public RoomBase1 West => _west;

    [SerializeField] private GameObject NorthDoor, EastDoor, SouthDoor, WestDoor;
    protected PlayerController _playerController;
    internal int Collision = 0;

    public virtual void SetRoomLocation(Vector3 coordinates)
    {
        transform.position = coordinates;
    }

    public virtual void OnRoomEntered()
    {
        Debug.Log("its a normal room");
    }
   
    public virtual void SetPlayerReference(PlayerController player)
    {
        _playerController = player;
    }

    public virtual void OnRoomExited()
    {

    }

    public virtual void OnRoomSearched()
    {
        Debug.Log("you find nothing");
    }

    public void SetRooms(RoomBase1 roomNorth, RoomBase1 roomEast, RoomBase1 roomSouth, RoomBase1 roomWest)
    {
        _north = roomNorth;
        NorthDoor.SetActive(_north == null);
        _east = roomEast;
        EastDoor.SetActive(_east == null);
        _south = roomSouth;
        SouthDoor.SetActive(_south == null);
        _west = roomWest;
        WestDoor.SetActive(_west == null);
    }



}
