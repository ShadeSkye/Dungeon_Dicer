using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRooms : RoomBase1
{
    [SerializeField] private GameObject[] Items;

    Vector3 roomCoords;
    private bool ItemHere = true;
    private GameObject itemInstance;
    public void Awake()
    {
         itemInstance = Instantiate(Items[Random.Range(0, Items.Length)], transform);
        itemInstance.transform.position = new Vector3(roomCoords.x, 6, roomCoords.y);
    }

    public new void SetRoomLocation(Vector3 coordinates)
    {
        roomCoords = coordinates;
    }

    public override void OnRoomEntered()
    {
        Debug.Log("theres lots of treasure in here!");
        if (ItemHere)
        {
            _playerController.ItemInPath = true;
            _playerController.current_item = itemInstance.GetComponent<ItemPickup>();
        }
    }

    public override void OnRoomSearched()
    {
        ItemHere = false;
    }
}
