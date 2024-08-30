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
            float playerHealth;
            float playerMana;
            int playerGold = 3;
            float playerArmor;
            string playerRole = "";
            int playerAgility;
            int playerStrength;
            bool isPlayerDead = false;

            Console.WriteLine("Hello, " + playerName + "!");
            Console.WriteLine();
            Console.WriteLine("Welcome to my dungeon!");
            Console.WriteLine();
            int input = GetInput("Are you a Warrior or are you a Wizard?", "Warrior", "Wizard");
            if (input == 1)
            {
                playerRole = "Warrior";
                playerAgility = 10;
                playerStrength = 10;
                playerMana = 5.0f;
                playerHealth = 30.0f;
                playerArmor = 5.0f;
                Console.WriteLine("You are a " + playerRole + ".");
                Console.WriteLine("Health: " + playerHealth);
                Console.WriteLine("Mana: " + playerMana);
                Console.WriteLine("Gold: " + playerGold);
                Console.WriteLine("Agility: " + playerAgility);
                Console.WriteLine("Strength: " + playerStrength);
                Console.WriteLine("Armor: " + playerArmor);
            }
            else if (input == 2)
            {
                playerRole = "Wizard";
                playerAgility = 3;
                playerStrength = 4;
                playerMana = 30.0f;
                playerHealth = 20.0f;
                playerArmor = 1.0f;
                Console.WriteLine("You are a " + playerRole + ".");
                Console.WriteLine("Health: " + playerHealth);
                Console.WriteLine("Mana: " + playerMana);
                Console.WriteLine("Gold: " + playerGold);
                Console.WriteLine("Agility: " + playerAgility);
                Console.WriteLine("Strength: " + playerStrength);
                Console.WriteLine("Armor: " + playerArmor);
            }
            Console.WriteLine();
            input = GetInput("You find yourself in a generic dungeon with two doors. Which door do you choose?", "Left", "Right");
            if (input == 1)
            {
                input = GetInput("You enter the left door, and...oh! It's a trap! The moment you enter, the door behind you locks shut. The ceiling is coated in sharp spikes that " +
                    "slowly start to descend. You see a lever at the far end of this room. What will you do?", "Run to Lever", "Use Spell");
                if (input == 1 && playerRole == "Warrior")
                {
                    Console.WriteLine("You think quickly and dash to the lever. Thanks to your high agility as a Warrior, you make it to the lever with time to spare. You pull " +
                        "it and the ceiling stops descending. You hear the click of a lock as the door unlocks, allowing you to go back to the original two doors and make the " +
                        "'Right' choice.");
                }
                else if (input == 1 && playerRole == "Wizard")
                {
                    Console.WriteLine("You decide to try and run to the lever. However, your low agility as a wizard does not allow you to move quickly enough to make it to " +
                        "the lever. As you are just a quarter away from the lever, the spikes fall on you and you die.");
                }
                else if (input == 2 && playerRole == "Warrior")
                {
                    Console.WriteLine("Despite the fact that you have no magical abilities as a Warrior, you attempt to use Telekinesis anyway. You put your fingers to your temple " +
                        "and strain really hard to try and somehow gain Telekinesis. This is obviously futile, however, as the spikes descend and crush you.");
                }
                else if (input == 2 && playerRole == "Wizard")
                {
                    Console.WriteLine("As a Wizard, you use your Telekinesis to pull the lever from afar. It works! The lever magically pulls and the ceiling stops falling. You " +
                        "hear the click of the door unlocking, allowing you to go back and make the 'Right' choice.");
                }
            }
            else if (input == 2)
            {
                Console.WriteLine("You enter the right door. You walk right into a Goblin! They ready themselves, prepared to strike. What will you do?");
            }

            /* Console.WriteLine("You find yourself in a generic dungeon with two doors. Which door do you choose?");
            while (input != "1" && input != "2")
            {
                Console.WriteLine("(Left: 1 | Right: 2)");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("You enter the left door, and...oh! It's a trap! The moment you enter, the door behind you locks shut. The ceiling is coated in sharp spikes that " +
                        "slowly start to descend. You see a lever at the far end of this room. What will you do?");
                    input = "";
                    while(input != "1" && input != "2")
                    {
                        Console.WriteLine("(Run to Lever: 1 | Use Telekinesis [Wizard ONLY]: 2");
                        input = Console.ReadLine();

                        if (input == "1" && playerRole == "Warrior")
                        {
                            Console.WriteLine("You think quickly and dash to the lever. Thanks to your high agility as a Warrior, you make it to the lever with time to spare. You pull " +
                                "it and the ceiling stops descending. You hear the click of a lock as the door unlocks, allowing you to go back to the original two doors and make the " +
                                "'Right' choice.");
                        } else if (input == "1" && playerRole == "Wizard")
                        {
                            Console.WriteLine("You decide to try and run to the lever. However, your low agility as a wizard does not allow you to move quickly enough to make it to " +
                                "the lever. As you are just a quarter away from the lever, the spikes fall on you and you die.");
                        } else if (input == "2" && playerRole == "Warrior")
                        {
                            Console.WriteLine("Despite the fact that you have no magical abilities as a Warrior, you attempt Telekinesis anyway. You put your fingers to your temple " +
                                "and strain really hard to try and somehow gain Telekinesis. This is obviously futile, however, as the spikes descend and crush you.");
                        } else if (input == "2" && playerRole == "Wizard")
                        {
                            Console.WriteLine("As a Wizard, you use your Telekinesis to pull the lever from afar. It works! The lever magically pulls and the ceiling stops falling. " +
                                "You hear the click of the door unlocking, allowing you to go back and make the 'Right' choice.");
                        }
                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("You enter the right door. You walk right into a Goblin! They ready themselves, prepared to strike. What will you do?");
                    input = "";
                }
            } */
        }

        int GetInput(string description, string option1, string option2)
        {
            string input = "";
            int inputReceived = 0;
            //Input loop
            while(inputReceived != 1 && inputReceived != 2)
            {
                //Print options
                Console.WriteLine(description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");

                //Get input from player
                input = Console.ReadLine();

                //if player selected the first option
                if(input == "1" || input == option1)
                {
                    //set inputReceived to be the first option
                    inputReceived = 1;
                }
                //otherwise if player selected the second option
                else if (input == "2" || input == option2)
                {
                    //set inputReceived to be the second option
                    inputReceived = 2;
                }
                //if neither are trye
                else
                {
                    //display error message
                    Console.WriteLine("Invalid Input");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            return inputReceived;
        }
    }
}
