using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWar.Characters
{
    internal interface ICharacter
    {
        public const int maxHealthLevel = 1000;
        string Race { get; }
        int HealthLevel { get; set; }
        int MeleeDamage { get; }
        int RangedDamage { get; }
    }
}