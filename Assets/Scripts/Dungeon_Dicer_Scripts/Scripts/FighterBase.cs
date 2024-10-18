using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DungeonDicer.Scripts
{
    internal class FighterBase
    {
        internal abstract class Fighters
        {
            internal int BaseDamage = 0;
            internal int TotalDamage = 0;
            internal int CurrentHP = 0;
            internal int PlayerMaxHp = 100;
            internal int Target = 0;

            /// <summary>
            /// This function is called wehn an enemy is spawned in
            /// </summary>
            internal abstract void OnSpawn();

            /// <summary>
            /// This function allows the fighters to take their turn
            /// </summary>
            internal abstract void TakeTurn(List<FighterBase.Fighters> Targets);

            /// <summary>
            /// This function sets the CurrentHP
            /// </summary>
            /// <param name="damage"></param>
            internal virtual void TakeDamage(int damage)
            {
                CurrentHP -= damage;
            }

            /// <summary>
            /// This function is called when an enemy dies
            /// </summary>
            internal abstract void OnDefeat();
        }

        /// <summary>
        /// Player class inherits from Fighters class
        /// </summary>
        internal class Player : Fighters
        {
            Random RandInt = new Random();
            internal override void OnSpawn()
            {
                CurrentHP = PlayerMaxHp;
                BaseDamage = 15;
                Console.WriteLine("Player spawned");
            }

            internal override void TakeTurn(List<FighterBase.Fighters> Enemies)
            {
                while(Target != 1 && Target != 2 && Target != 3)
                {
                    Console.WriteLine("Pick a target [1, 2 ,3]");
                    Target = Console.Read();
                }

                TotalDamage = BaseDamage + RandInt.Next(-3, 4);
            }

            internal override void OnDefeat()
            {

            }
        }

        /// <summary>
        /// Boss class inherits from Fighters class
        /// </summary>
        internal class Boss : Fighters
        {
            Random RandInt = new Random();
            internal override void OnSpawn()
            {
                CurrentHP = 150;
                BaseDamage = 10;
            }

            internal override void TakeTurn(List<FighterBase.Fighters> Player)
            {
                Target = 0;
                TotalDamage += BaseDamage + RandInt.Next(-3, 4);
                Player[0].TakeDamage(TotalDamage);
            }

            internal override void OnDefeat()
            {

            }
        }

        /// <summary>
        /// Skeleton class inherits from Fighters class
        /// </summary>
        internal class Skeleton : Fighters
        {
            Random RandInt = new Random();
            internal override void OnSpawn()
            {
                CurrentHP = 30;
                BaseDamage = 7;

                Console.WriteLine("Skeleton has appeared!");
            }

            internal override void TakeTurn(List<FighterBase.Fighters> Player)
            {
                Target = 0;
                TotalDamage += BaseDamage + RandInt.Next(-3, 4);
                Player[0].TakeDamage(TotalDamage);
            }

            internal override void OnDefeat()
            {

            }
        }

        /// <summary>
        /// Ghost internal int PlayerMaxHp = 100;
        /// </summary>
        internal class Ghost : Fighters
        {
            Random RandInt = new Random();
            internal override void OnSpawn()
            {
                CurrentHP = 45;
                BaseDamage = 4;

                Console.WriteLine("Ghost has appeared!");
            }

            internal override void TakeTurn(List<FighterBase.Fighters> Player)
            {
                Target = 0;
                TotalDamage += BaseDamage + RandInt.Next(-3, 4);
                Player[0].TakeDamage(TotalDamage);
            }
            
            internal override void OnDefeat()
            {

            }
        }
    }
}
