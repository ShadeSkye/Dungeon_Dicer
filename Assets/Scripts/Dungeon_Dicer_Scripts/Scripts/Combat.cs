using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonDicer.Scripts
{
    internal class Combat
    {
        static GameManager GameManagerInstance = new GameManager();

        List<FighterBase.Fighters> PlayerList = new List<FighterBase.Fighters>();

        

        internal int DamageDelt = 0;

        /// <summary>
        /// This function is called to start the combat loop
        /// </summary>
        internal void StartCombat(List<FighterBase.Fighters> EnemyList, List<FighterBase.Fighters> PlayerList)
        {
            foreach (FighterBase.Fighters f in EnemyList)
            {
                f.OnSpawn();
            }

            while (EnemyList.Count > 0)
            {
                Console.WriteLine("combat has begun");

                GameManagerInstance.PlayerInstance.TakeTurn(EnemyList);

                foreach (FighterBase.Fighters enemies in EnemyList)
                {
                    enemies.TakeTurn(PlayerList);
                }

                break;
            }
        }
    }
}
