using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DungeonDicer.Scripts
{
    internal class RoomBase : MonoBehaviour
    {
        /// <summary>
        /// Abstract Rooms class
        /// </summary>
        internal abstract class Rooms
        {
            internal Combat CombatInstance = new Combat();

            internal GameManager GameManagerInstance = new GameManager();

            internal FighterBase.Fighters Fighter1;

            internal FighterBase.Fighters Fighter2;

            internal FighterBase.Fighters Fighter3;

            internal System.Random RandInt = new System.Random();

            internal string RoomDescription = "Description of current room";

            internal bool IsRoomCleared = false;

            internal int Enemy1 = 0;

            internal int Enemy2 = 0;

            internal int Enemy3 = 0;


            Dictionary<string,Rooms> destination = new Dictionary<string,Rooms>();


            internal virtual void SetRoomDestination(string key, Rooms room)
            {
                destination[key] = room;
            }

            /// <summary>
            /// This function is called everytime you enter a room
            /// </summary>
            internal virtual void OnRoomEntered()
            {
                Console.WriteLine(RoomDescription); // Room description
            }


            internal virtual void OnRoomSearched()
            {

            }
            
            /// <summary>
            /// This function is used to get the next room from the dictionary
            /// </summary>
            /// <param name="Input"></param>
            /// <returns></returns>
            internal virtual Rooms GetDirection(string Input)
            {
                try
                {
                    return destination[Input];
                }
                catch
                {
                    return null;
                }
            }

        }

        /// <summary>
        /// SpawnRoom class inherits from Rooms class
        /// </summary>
        internal class SpawnRoom : Rooms
        {
            internal override void OnRoomEntered()
            {
                RoomDescription = "Spawn Room"; // CHANGE DESCRIPTION
                base.OnRoomEntered();
            }
        }

        /// <summary>
        /// EmptyRoom class inherits from Rooms class
        /// </summary>
        internal class EmptyRoom : Rooms
        {
            internal override void OnRoomEntered()
            {
                RoomDescription = "Empty Room"; // CHANGE DESCRIPTION
                base.OnRoomEntered();
            }
        }

        /// <summary>
        /// TreasureRoom class inherits from Rooms class
        /// </summary>
        internal class TreasureRoom : Rooms
        {
            internal override void OnRoomEntered()
            {
                RoomDescription = "Treasure Room"; // CHANGE DESCRIPTION
                base.OnRoomEntered();
            }

            internal override void OnRoomSearched()
            {

            }
        }

        /// <summary>
        /// EnenmyRoom class inherits from Rooms class
        /// </summary>
        internal class EnemyRoom : Rooms
        {

            List<FighterBase.Fighters> Enemies;
            internal EnemyRoom()
            {
                Enemy1 = RandInt.Next(0, 2);

                Enemy2 = RandInt.Next(0, 2);

                Enemy3 = RandInt.Next(0, 2);

                Enemies = new List<FighterBase.Fighters>();

                if (Enemy1 == 0)
                {
                    Fighter1 = new FighterBase.Skeleton();
                    Enemies.Add(Fighter1);
                }

                else if (Enemy1 == 1)
                {
                    Fighter1 = new FighterBase.Ghost();
                    Enemies.Add(Fighter1);
                }

                if (Enemy2 == 0)
                {
                    Fighter2 = new FighterBase.Skeleton();
                    Enemies.Add(Fighter2);
                }

                else if (Enemy2 == 1)
                {
                    Fighter2 = new FighterBase.Ghost();
                    Enemies.Add(Fighter2);
                }

                if (Enemy3 == 0)
                {
                    Fighter3 = new FighterBase.Skeleton();
                    Enemies.Add(Fighter3);
                }

                else if (Enemy3 == 1)
                {
                    Fighter3 = new FighterBase.Ghost();
                    Enemies.Add(Fighter3);
                }
            }

            internal override void OnRoomEntered()
            {
                RoomDescription = "Enemy Room"; // CHANGE DESCRIPTION
                base.OnRoomEntered();

                if (!IsRoomCleared)
                {
                    Console.WriteLine(Enemy1 + "\n" + Enemy2 + "\n" + Enemy3);
                    CombatInstance.StartCombat(Enemies, GameManagerInstance.PlayerTarget);
                }
            }
        }

        /// <summary>
        /// BossRoom class inherits from EnemyRoom class
        /// </summary>
        internal class BossRoom : Rooms
        {
            List<FighterBase.Fighters> Enemies;

            internal BossRoom()
            {
                Enemy1 = RandInt.Next(0, 2);

                Enemy3 = RandInt.Next(0, 2);

                Enemies = new List<FighterBase.Fighters>();

                if (Enemy1 == 0)
                {
                    Fighter1 = new FighterBase.Skeleton();
                    Enemies.Add(Fighter1);
                }

                else if (Enemy1 == 1)
                {
                    Fighter1 = new FighterBase.Ghost();
                    Enemies.Add(Fighter1);
                }

                Fighter2 = new FighterBase.Boss();
                Enemies.Add(Fighter2);

                if (Enemy3 == 0)
                {
                    Fighter3 = new FighterBase.Skeleton();
                    Enemies.Add(Fighter3);
                }

                else if (Enemy3 == 1)
                {
                    Fighter3 = new FighterBase.Ghost();
                    Enemies.Add(Fighter3);
                }
            }

            internal override void OnRoomEntered()
            {
                RoomDescription = "Boss Room"; // CHANGE DESCRIPTION
                base.OnRoomEntered();
            }
        }
    }
}
