using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Dungeon
{
    internal class Game
    {
        public void Run()
        {
            string playerName = "Bobbifuus";
            float playerHealth = 10.0f;
            float playerMana = 5.0f;
            int playerGold = 3;
            float playerArmor = 5.0f;
            string playerRole = "Warrior";

            Console.WriteLine("Hello, " + playerName + "!");
            Console.WriteLine();
            Console.WriteLine("Welcome to my dungeon!");
            Console.WriteLine();
            Console.WriteLine("Health: " + playerHealth);
            Console.WriteLine("Mana: " + playerMana);
            Console.WriteLine("Gold: " + playerGold);
            Console.WriteLine("Are you a Warrior or are you a Wizard?");
            string input = "";
            
            while (input != "1" && input != "2")
            {
                Console.WriteLine("(Warrior: 1 | Wizard: 2)");
                input = Console.ReadLine();
                
                if (input == "1")
                {
                    playerRole = "Warrior";
                }
                else if (input == "2")
                {
                    playerRole = "Wizard";
                }
            }
            Console.WriteLine("Player role: " + playerRole);
            Console.WriteLine();
            input = "";
            Console.WriteLine("You find yourself in a generic dungeon with two doors. Which door do you choose?");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("(Left: 1 | Right: 2)");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("You enter the left door.");
                }
                else if (input == "2")
                {
                    Console.WriteLine("You enter the right door.");
                }
            }
        }
    }
}
