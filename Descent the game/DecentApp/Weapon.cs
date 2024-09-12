using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecentApp
{
    public class Weapon
    {
        public string Name { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public Weapon(string name, int minDamage, int maxDamage)
        {
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
        }
    }
}
