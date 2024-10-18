using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DungeonDicer.Scripts;
using UnityEngine;

namespace DungeonDicer
{
    internal class GameManager : MonoBehaviour
    {
        static MapGenerator MapGeneratorInstance = new MapGenerator();

        internal FighterBase.Fighters PlayerInstance = new FighterBase.Player();

        internal List<FighterBase.Fighters> PlayerTarget = new List<FighterBase.Fighters>();

        private RoomBase.Rooms CurrentRoom;

        private string PlayerWantsToPlay = "";

        private string PlayerDirection = "";

        private int mapSize = 15;

        public void Start()
        {
            VisualizeMap();
            //StartGame();
        }

        /// <summary>
        /// This function creates a typewriter effect.
        /// </summary>
        private void Print(string text, int speed = 20)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
        }

        private void VisualizeMap()
        {
            for (int x = 0; x < mapSize; x+= 5)
            {
                for (int z = 0; z < mapSize; z+= 5)
                {
                    var mapRoomRepresentation = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    mapRoomRepresentation.transform.localScale += new Vector3(4, 0, 4);
                    mapRoomRepresentation.transform.position = new Vector3(x, 0, z);
                }
            }
        }

        internal void StartGame()
        {
            MapGeneratorInstance.GenerateMap();
            CurrentRoom = MapGeneratorInstance._spawnRoom;
            PlayerTarget.Add(PlayerInstance);
            //Welcome();
            //AskToPlay();
            Play();
        }
        
        /// <summary>
        /// Welcomes the player to the game and shows the title of the game.
        /// </summary>
        internal void Welcome()
        {
            // Welcome message and title made using the text to ASCII art feature on ASCII Art Archive using the "Wet Letter" font.
            Debug.Log(".-.  .-.,---.  ,-.    ,--,  .---.           ,---.    _______  .---.  \r\n| |/\\| || .-'  | |  .' .') / .-. ) |\\    /| | .-'   |__   __|/ .-. ) \r\n| /  \\ || `-.  | |  |  |(_)| | |(_)|(\\  / | | `-.     )| |   | | |(_)\r\n|  /\\  || .-'  | |  \\  \\   | | | | (_)\\/  | | .-'    (_) |   | | | | \r\n|(/  \\ ||  `--.| `--.\\  `-.\\ `-' / | \\  / | |  `--.    | |   \\ `-' / \r\n(_)   \\|/( __.'|( __.'\\____\\)---'  | |\\/| | /( __.'    `-'    )---'  \r\n       (__)    (_)         (_)     '-'  '-'(__)              (_)     ");
            Debug.Log("\n\n ,'|\"\\   .-. .-..-. .-.  ,--,   ,---.   .---.  .-. .-.\r\n | |\\ \\  | | | ||  \\| |.' .'    | .-'  / .-. ) |  \\| |\r\n | | \\ \\ | | | ||   | ||  |  __ | `-.  | | |(_)|   | |\r\n | |  \\ \\| | | || |\\  |\\  \\ ( _)| .-'  | | | | | |\\  |\r\n /(|`-' /| `-')|| | |)| \\  `-) )|  `--.\\ `-' / | | |)|\r\n(__)`--' `---(_)/(  (_) )\\____/ /( __.' )---'  /(  (_)\r\n               (__)    (__)    (__)    (_)    (__)    \r\n ,'|\"\\   ,-.  ,--,  ,---.  ,---.                      \r\n | |\\ \\  |(|.' .')  | .-'  | .-.\\                     \r\n | | \\ \\ (_)|  |(_) | `-.  | `-'/                     \r\n | |  \\ \\| |\\  \\    | .-'  |   (                      \r\n /(|`-' /| | \\  `-. |  `--.| |\\ \\                     \r\n(__)`--' `-'  \\____\\/( __.'|_| \\)\\                    \r\n                   (__)        (__)      ");
        }
        
        /// <summary>
        /// This function is responsible for asking if the player wants to play the game.
        /// </summary>
        internal void AskToPlay()
        {
            Print("\n\nWould you like to play? [please enter \"yes\" or \"no\"]");

            Console.Write("\n\nYou: ");
            PlayerWantsToPlay = Console.ReadLine();
            PlayerWantsToPlay = PlayerWantsToPlay.ToLower();

            while (PlayerWantsToPlay != "yes" && PlayerWantsToPlay != "no")
            {
                Console.WriteLine("\nThat is not a suitable answer.");
                Print("\n\nWould you like to play? [please enter \"yes\" or \"no\"]");

                Console.Write("\n\nYou: ");
                PlayerWantsToPlay = Console.ReadLine();
                PlayerWantsToPlay = PlayerWantsToPlay.ToLower();
            }

            if (PlayerWantsToPlay == "no")
            {
                Print("Suit yourself.");
                Environment.Exit(0);
            }
        }
        
        internal void Play()
        {
            CurrentRoom.OnRoomEntered();

            while (PlayerDirection != "N" && PlayerDirection != "E" && PlayerDirection != "S" && PlayerDirection != "W")
            {
                Debug.Log("\nChoose a valid direction [\"N\" \"E\" \"S\" \"W\"]\n");
                PlayerDirection = Console.ReadLine();
                PlayerDirection = PlayerDirection.ToUpper();

                CurrentRoom.GetDirection(PlayerDirection);

                if (CurrentRoom.GetDirection(PlayerDirection) == null)
                {
                    Debug.Log("There is no room there");
                    PlayerDirection = "";
                }
            }

            CurrentRoom = CurrentRoom.GetDirection(PlayerDirection);

            PlayerDirection = "";

            Play();
        }
    }
}
