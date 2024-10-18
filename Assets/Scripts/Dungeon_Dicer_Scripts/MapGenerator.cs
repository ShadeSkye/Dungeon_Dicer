using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonDicer.Scripts;
using UnityEngine;

namespace DungeonDicer
{
    internal class MapGenerator : MonoBehaviour
    {
        public RoomBase.Rooms _spawnRoom = new RoomBase.SpawnRoom(); //1

        public RoomBase.Rooms _treasureRoom1 = new RoomBase.TreasureRoom(); //3
        public RoomBase.Rooms _treasureRoom2 = new RoomBase.TreasureRoom(); //4
        public RoomBase.Rooms _treasureRoom3 = new RoomBase.TreasureRoom(); //8

        public RoomBase.Rooms _emptyRoom = new RoomBase.EmptyRoom(); //2

        public RoomBase.Rooms _enemyRoom1 = new RoomBase.EnemyRoom(); //5
        public RoomBase.Rooms _enemyRoom2 = new RoomBase.EnemyRoom(); //6
        public RoomBase.Rooms _enemyRoom3 = new RoomBase.EnemyRoom(); //7

        public RoomBase.Rooms _bossRoom = new RoomBase.BossRoom(); //9

        internal void GenerateMap()
        {
            //ROOM 1 North exit/ROOM 4 South exit
            _spawnRoom.SetRoomDestination("N", _treasureRoom2);
            _treasureRoom2.SetRoomDestination("S", _spawnRoom);

            //ROOM 1 East exit/ROOM 2 West exit
            _spawnRoom.SetRoomDestination("E", _emptyRoom);
            _emptyRoom.SetRoomDestination("W", _spawnRoom);

            //ROOM 2 North exit/ROOM 5 South exit
            _emptyRoom.SetRoomDestination("N", _enemyRoom1);
            _enemyRoom1.SetRoomDestination("S", _emptyRoom);

            //ROOM 2 East exit/ROOM 3 West exit
            _emptyRoom.SetRoomDestination("E", _treasureRoom1);
            _treasureRoom1.SetRoomDestination("W", _emptyRoom);

            //ROOM 3 North exit/ROOM 6 South exit
            _treasureRoom1.SetRoomDestination("N", _enemyRoom2);
            _enemyRoom2.SetRoomDestination("S", _treasureRoom1);

            //ROOM 4 North exit/ROOM 7 South exit
            _treasureRoom2.SetRoomDestination("N", _enemyRoom3);
            _enemyRoom3.SetRoomDestination("S", _treasureRoom2);

            //ROOM 4 East exit/ROOM 5 West exit
            _treasureRoom2.SetRoomDestination("E", _enemyRoom1);
            _enemyRoom1.SetRoomDestination("W", _treasureRoom2);

            //ROOM 5 North exit/ROOM 8 South exit
            _enemyRoom1.SetRoomDestination("N", _treasureRoom3);
            _treasureRoom3.SetRoomDestination("S", _enemyRoom1);

            //ROOM 5 East exit/ROOM 6 West exit
            _enemyRoom1.SetRoomDestination("E", _enemyRoom2);
            _enemyRoom2.SetRoomDestination("W", _enemyRoom1);

            //ROOM 6 North exit/Room 9 South exit
            _enemyRoom2.SetRoomDestination("N", _bossRoom);
            _bossRoom.SetRoomDestination("S", _enemyRoom2);

            //ROOM 7 East exit/ROOM 8 West exit
            _enemyRoom3.SetRoomDestination("E", _treasureRoom3);
            _treasureRoom3.SetRoomDestination("W", _enemyRoom3);

            //ROOM 8 East exit/ROOM 9 West exit
            _treasureRoom3.SetRoomDestination("E", _bossRoom);
            _bossRoom.SetRoomDestination("W", _treasureRoom3);

        }
    }
}
