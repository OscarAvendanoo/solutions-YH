using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace DecentApp
{
    internal class Character
    {
        private int experience;
        public bool Dead { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public int BaseDamage { get; set; }

        public Weapon Weapon { get; set; }

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
            Dead = false;
            BaseDamage = 1;
            Level = 1;
        }

        public void Attack(Character character, Monster monster)
        {
            if (!IsDead())
            {
                Random random = new Random();
                int minValue = character.Weapon.MinDamage; 
                int maxValue = character.Weapon.MaxDamage;
                int hitDamageCharacter = random.Next(minValue, maxValue + 1) + GetExtraDamage();
                monster.Health = monster.Health - hitDamageCharacter; 
                Console.WriteLine($"{monster.Name} lost {hitDamageCharacter} and has {monster.Health} HP remaining");
                Thread.Sleep(500);
            }
        }
        public int GetExtraDamage()
        {
            return BaseDamage * Level;
        }
        public void AddExperience(int expAmount)
        {
            experience += expAmount;
            if(experience > 50)
            {
                
                Level += 1;
                experience = 0;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You are now level " + Level + " and feel abit stronger");
                Console.ForegroundColor= ConsoleColor.Green;
            }
        }
        public bool IsDead()
        {
            if (Health <= 0)
            {
                Dead = true;
                return Dead;
            }
            return false;
        }

    }
}
