using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Xml.Xsl;
using static System.Net.Mime.MediaTypeNames;

namespace DecentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeaponList weaponList = new WeaponList();
            MonsterGenerator monsterGenerator = new MonsterGenerator();
            Monster monster;
            Monster boss;
            Story story = new Story();
            Character player;
            Random random = new Random();

            Color colorWrite = new Color(ConsoleColor.Green); // Sätta lite färg på spelet enklare.

            bool reachedBoss = false;
            bool playing = true;
            int storyCounter = 0;

            string gameNameText = "Descent";

            // Sätter basfärgen i consolen.
            colorWrite.ResetColor();

            // Visar intro och meny för spelet.
            player = Menu();

            while (playing)
            {
                Console.Clear();

                               
                // Slumpa monster och ett vapen.
                monster = monsterGenerator.monsters[random.Next(0, monsterGenerator.monsters.Count() - 1)];
                monster.Weapon = weaponList.weapons[random.Next(0, weaponList.weapons.Count() - 1)];
                boss = monsterGenerator.monsters[monsterGenerator.monsters.Count() - 1];
                boss.Weapon = weaponList.weapons[weaponList.weapons.Count() - 1];


                // Spela storyn
                if (storyCounter < story.storySentences.Count())
                {
                    Console.WriteLine(story.storySentences[storyCounter]);
                    Console.WriteLine();
                }

                
                if (storyCounter < story.storySentences.Count())
                {
                    // ´monsterfight
                    player.Weapon = weaponList.dagger;

                    colorWrite.Yellow("A ");
                    colorWrite.Blue(monster.Name);
                    colorWrite.Yellow(" suddenly appears with a ");
                    colorWrite.Blue(monster.Weapon.Name);
                    colorWrite.Yellow("! What do u do?\n\n");
                }
                else
                {
                    // Bossfight
                    colorWrite.Yellow($"The ground trembles beneath your feet as a deafening roar echoes through the cavern. From the shadows,\n ");
                    colorWrite.Red($"{boss.Name}");
                    colorWrite.Yellow(" emerges, his scales glistening like molten lava, eyes burning with ancient fury.\n");
                    colorWrite.Cyan("YOU DARE CHALLANGE ME, MORTAL? PREPARE TO BE CONSUMED BY FIRE AND FURY!\n");
                    colorWrite.Yellow("The air thickens with heat as the dragon spreads its colossal wings, ready to unleash its wrath upon you.\n\n");
                    reachedBoss = true;
                }

                //
                Console.WriteLine($"Health: {player.Health} Level: {player.Level}");
                Console.WriteLine();
                Console.WriteLine("(A) Attack.");
                Console.WriteLine("(F) Flee like a chicken.");

                Console.WriteLine();
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "A":
                    case "a":
                        // Attack koden.
                        if (storyCounter < story.storySentences.Count())
                        {
                            playing = Battle(monster, player, colorWrite, playing);
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            playing = Battle(boss, player, colorWrite, playing);
                            Thread.Sleep(2000);
                        }


                        break;
                    case "F":
                    case "f":
                        // Random event, succeed flee or battle.
                        if (reachedBoss)
                        {
                            colorWrite.Cyan("HA HA HA, You cannot flee from me!! Prepare to fight!\n");
                            playing = Battle(boss, player, colorWrite, playing);
                            Thread.Sleep(2000);
                            break;
                        }
                        else
                        {
                            Random rand = new Random();
                            int luckyNumber = rand.Next(0, 3);
                            if (luckyNumber == 1)
                            {
                                // flee text break switch
                                colorWrite.Yellow("You managed to flee\n");
                                Thread.Sleep(2000);
                                break;
                            }
                            else
                            {
                                colorWrite.Red("Sadly you fumble and stumble and didnt manage to escape..\n");
                                playing = Battle(monster, player, colorWrite, playing);
                                Thread.Sleep(2000);
                                break;
                            }
                        }

                    default:
                        // Måste göra nåt åt denna sen om vi hinner.
                        Console.WriteLine("Must enter a valid choice.");
                        break;
                }

                storyCounter++;
            }

        }

        private static bool Battle(Monster monster, Character player, Color colorWrite, bool playing)
        {
            Console.WriteLine(Encounter(player, monster));
            // if sats om spelaren lever isf avsluta. annars fortsätt.
            if (player.IsDead())
            {
                Thread.Sleep(4000);
                Console.Clear();
                colorWrite.Red(" YOU SUCK, GAME OVER !");
                playing = false;
                Console.ReadLine();
            }           
            
            return playing;
        }

        private static string Encounter(Character player, Monster monster)
        {
            Console.WriteLine("A fierce battle appears and ..");
            Console.WriteLine();

            while (true)
            {
                if (player.IsDead())
                {
                    return "You died";
                }
                else if (monster.IsDead())
                {
                    monster.Dead = false;
                    monster.Health = 20;
                    player.AddExperience(monster.ExperienceReward);
                    player.Health += 10;
                    return $"{monster.Name} died. You earned {monster.ExperienceReward} exp. And restored some health";
                }
                else
                {
                    player.Attack(player, monster);
                    monster.Attack(player, monster);
                }
            }
        }
        private static Character Menu()
        {
            Character player;

            GameHeader();

            Console.WriteLine();
            Console.WriteLine("Deep within the Forgotten Mountains lay the vast, eerie caverns known as Shadow Hollow, rumored to be home to ancient treasures and mysterious creatures. Among the most feared inhabitants were the intelligent, shadow-born rats, led by their enormous, scarred king, Gnash. These rats, with their glowing red eyes and cunning minds, waited patiently for humans to venture too far into their dark domain.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Press enter to start Adventure.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter your forgotten name: ");
            string name = Console.ReadLine();
            player = new Character(name, 100);

            // Fråga vilket vapen spelaren vill ha.

            return player;
        }

        private static void GameHeader()
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            List<string> Header = new List<string>();
            string decentHeader1 = " ####  #####  #####  #####  #####  #   #  ##### ";
            string decentHeader2 = " #   # #      #      #      #      ##  #    #   ";
            string decentHeader3 = " #   # #####  #####  #      #####  # # #    #   ";
            string decentHeader4 = " #   # #          #  #      #      #  ##    #   ";
            string decentHeader5 = " ####  #####  #####  #####  #####  #   #    #   ";
            Header.Add(decentHeader1);
            Header.Add(decentHeader2);
            Header.Add(decentHeader3);
            Header.Add(decentHeader4);
            Header.Add(decentHeader5);

            foreach (string header in Header)
            {
                for (int i = 0; header.Length > i; i++)
                {
                    Console.Write(header[i]);
                    Thread.Sleep(30);
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
