using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWar.Characters
{
    internal class Gnome : ICharacter
    {
        public Gnome()
        {
            _healthLevel = ICharacter.maxHealthLevel;
        }

        readonly string _race = "Gnome";
        private int _healthLevel;
        private int _meelDamage = 70;
        private int _rangedDamage = 20;
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