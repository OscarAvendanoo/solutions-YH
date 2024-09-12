using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentApp
{
    internal class MonsterGenerator
    {
        public List<Monster> monsters;
        
        public MonsterGenerator()
        {
            monsters = new List<Monster>();

            Monster rat = new Monster(20, "Rat", 15);
            Monster goblin = new Monster(20, "Goblin", 35);
            Monster orc = new Monster(20, "Orc", 35);
            Monster falcon = new Monster(20, "Falcon", 20);
            Monster dragon = new Monster(200, "Dragon of Fire and Doom", 100);

            monsters.Add(rat);
            monsters.Add(goblin);            
            monsters.Add(orc);
            monsters.Add(falcon);

            monsters.Add(dragon);

        }
    }
}
