using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Dungeon
{
    internal class Game
    {
        struct Player
        {
            public float health;
            public float mana;
            public int strength;
            public int magic;
            public int agility;
            public int gold;
            public float armor;
            public string role;

            public Player(float health, float mana, int strength, int magic, int agility, int gold, float armor, string role)
            {
                this.health = health;
                this.mana = mana;
                this.strength = strength;
                this.magic = magic;
                this.agility = agility;
                this.gold = gold;
                this.armor = armor;
                this.role = role;
            }
        }
        struct Enemy
        {
            public float health;
            public int strength;
            public float armor;
            public string type;
            
            public Enemy(float health, int strength, float armor, string type)
            {
                this.health = health;
                this.strength = strength;
                this.armor = armor;
                this.type = type;
            }
        }
        public void Run()
        {
            bool isPlayerDead = false;
            /*while (isPlayerDead == false)
            {
                if (currentArea == 1)
                {
                    Room1();
                }
                if (currentArea == 2)
                {
                    Room2();
                }
                if (currentArea == 3)
                {
                    Room3();
                }
                if (playerIsAlive == false || currentArea == 3)
                {
                    DisplayMainMenu();
                }
                else if (playerIsAlive == true && currentArea != 3)
                {
                    currentArea++;
                }

            }*/

            Console.WriteLine("Hello, Player!");
            Console.WriteLine();
            Console.WriteLine("Welcome to my dungeon!");
            Console.WriteLine();
            int input = GetInput("Are you a Warrior or are you a Wizard?", "Warrior", "Wizard");
            Player player = new Player(health: 100, mana: 30, strength: 80, magic: 0, agility: 50, gold: 0, armor: 30, role: "");
            if (input == 1)
            {
                player.role = "Warrior";
                Console.WriteLine("You are a Warrior!");
                Console.WriteLine();
                PrintPlayerStats(player);
            }
            else if (input == 2)
            {
                player.health = 70;
                player.mana = 80;
                player.strength = 20;
                player.magic = 80;
                player.agility = 20;
                player.armor = 10;
                player.role = "Wizard";
                Console.WriteLine("You are a Wizard!");
                Console.WriteLine();
                PrintPlayerStats(player);
            }
            Console.WriteLine();
            input = GetInput("You find yourself in a generic dungeon with two doors. Which door do you choose?", "Left", "Right");
            if (input == 1)
            {
                input = GetInput("You enter the left door, and...oh! It's a trap! The moment you enter, the door behind you locks shut. The ceiling is coated in sharp spikes that " +
                    "slowly start to descend. You see a lever at the far end of this room. What will you do?", "Run to Lever", "Use Spell");
                if (input == 1 && player.role == "Warrior")
                {
                    Console.WriteLine("You think quickly and dash to the lever. Thanks to your high agility as a Warrior, you make it to the lever with time to spare. You pull " +
                        "it and the ceiling stops descending. You hear the click of a lock as the door unlocks, allowing you to go back to the original two doors and make the " +
                        "'Right' choice.");
                }
                else if (input == 1 && player.role == "Wizard")
                {
                    Console.WriteLine("You decide to try and run to the lever. However, your low agility as a wizard does not allow you to move quickly enough to make it to " +
                        "the lever. As you are just a quarter away from the lever, the spikes fall on you and you die.");
                }
                else if (input == 2 && player.role == "Warrior")
                {
                    Console.WriteLine("Despite the fact that you have no magical abilities as a Warrior, you attempt to use Telekinesis anyway. You put your fingers to your temple " +
                        "and strain really hard to try and somehow gain Telekinesis. This is obviously futile, however, as the spikes descend and crush you.");
                }
                else if (input == 2 && player.role == "Wizard")
                {
                    Console.WriteLine("As a Wizard, you use your Telekinesis to pull the lever from afar. It works! The lever magically pulls and the ceiling stops falling. You " +
                        "hear the click of the door unlocking, allowing you to go back and make the 'Right' choice.");
                }
            }
            else if (input == 2)
            {
                Enemy goblin = new Enemy(50, 5, 0, "Goblin");
                while (goblin.health > 0)
                {
                    input = GetInput("You enter the right door, and walk right into a " + goblin.type + "! They ready themselves, prepared to strike. What will you do?", "Attack", "Spell");
                    if (input == 1)
                    {
                        Console.WriteLine("You strike the goblin and deal " + damageDealing(player.strength, goblin.armor, goblin.health) + " damage!");
                        Console.WriteLine("The " + goblin.type + " counterattacks and deals " + damageDealing(goblin.strength, player.armor, player.health) + " damage!");
                        goblin.health -= damageDealing(player.strength, goblin.armor, goblin.health);
                        player.health -= damageDealing(goblin.strength, player.armor, player.health);
                        Console.ReadKey();
                    }
                    else if (input == 2)
                    {
                        if (player.magic == 0)
                        {
                            Console.WriteLine("You don't have any spells!");
                            Console.WriteLine("The " + goblin.type + " seizes this opportunity and deals " + damageDealing(goblin.strength, player.armor, player.health) + " " +
                                "damage to you!");
                            player.health -= damageDealing(goblin.strength, player.armor, player.health);
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You cast a Fireball and deal " + damageDealing(player.magic, goblin.armor, goblin.health) + " damage!");
                            Console.WriteLine("Shaking off the fire, the " + goblin.type + " runs up and strike you for " + damageDealing(goblin.strength, player.armor, player.health)
                                + " damage");
                            goblin.health -= damageDealing(player.magic, goblin.armor, goblin.health);
                            player.health -= damageDealing(goblin.strength, player.armor, player.health);
                            Console.ReadKey();

                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("You have slain the " + goblin.type + "!");
            }
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
        static void PrintPlayerStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Mana: " + player.mana);
            Console.WriteLine("Strength: " + player.strength);
            Console.WriteLine("Agility: " + player.agility);
            Console.WriteLine("Gold: " + player.gold);
            Console.WriteLine("Armor: " + player.armor);
            Console.WriteLine("Role: " + player.role);
        }

        static float damageDealing(int a, float b, float c)
        {
            //a is attacking entity's strength, b is victim's armor, c is victim's health, d (below) is how much damage is dealt
            float d = a - b;
            c -= d;
            if(d < 0)
            {
                return 0;
            }
            else
            {
            return d;
            }
        }
    }
}
