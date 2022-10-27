using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWar.Characters
{
    internal class Elf : ICharacter
    {
        public Elf()
        {
            _healthLevel = ICharacter.maxHealthLevel;
        }

        readonly string _race = "Elf";
        private int _healthLevel;
        private int _meelDamage = 40;
        private int _rangedDamage = 80;
        public string Race => _race;
        public int HealthLevel
        {
            get => _healthLevel;
            set => _healthLevel = value;
        }
        public int MeleeDamage => _meelDamage;
        public int RangedDamage => _rangedDamage;
    }
}
