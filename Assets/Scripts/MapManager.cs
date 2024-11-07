using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private RoomBase1[] RoomPrefabs;
    [SerializeField] private float RoomSize = 1;

    private int MapSize = 10;

    public Dictionary<Vector3, RoomBase1> _rooms = new Dictionary<Vector3, RoomBase1>();

    /// <summary>
    /// Create rooms using prefabs
    /// </summary>
    public void CreateMap()
    {
        for(int x = 0; x < MapSize; x++)
        {
            for(int z = 0; z <MapSize; z++)
            {
                Vector3 coords = new Vector3(x * RoomSize, 0, z * RoomSize);

                var roomInstance = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)], transform);

                roomInstance.SetRoomLocation(coords);

                _rooms.Add(coords, roomInstance);
            }
        }

        foreach (var roomByCoordinate in _rooms)
        {
            RoomBase1 northRoom = FindRoom(roomByCoordinate.Key, Direction.North);
            RoomBase1 eastRoom = FindRoom(roomByCoordinate.Key, Direction.East);
            RoomBase1 southRoom = FindRoom(roomByCoordinate.Key, Direction.South);
            RoomBase1 westRoom = FindRoom(roomByCoordinate.Key, Direction.West);

            roomByCoordinate.Value.SetRooms(northRoom, eastRoom, southRoom, westRoom);
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West,
    }

    private RoomBase1 FindRoom(Vector3 currentRoom, Direction direction)
    {
        RoomBase1 room = null;
        Vector3 nextRoomCoordinates = new Vector3(-1, 0, -1);
        switch (direction)
        {
            case Direction.North:
                nextRoomCoordinates = currentRoom + (Vector3.forward * RoomSize);
                break;

            case Direction.East:
                nextRoomCoordinates = currentRoom + (Vector3.right * RoomSize);
                break;

            case Direction.South:
                nextRoomCoordinates = currentRoom + (Vector3.back * RoomSize);
                break;

            case Direction.West:
                nextRoomCoordinates = currentRoom + (Vector3.left * RoomSize);
                break;
        }

        if(_rooms.TryGetValue(nextRoomCoordinates, out var nextRoom))
        {
            room = nextRoom;
        }

        return room;
    }
}
