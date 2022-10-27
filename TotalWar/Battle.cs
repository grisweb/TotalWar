using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalWar.Characters;

namespace TotalWar
{
    internal class Battle
    {
        protected CharactersObjectPool _pool;

        protected int _currentWinnerId;

        protected double _rangedAdvantage;

        protected double _meleeAdvantage;

        public Battle()
        {
            _pool = new CharactersObjectPool();

            _currentWinnerId = 0;

            _rangedAdvantage = new Random().NextDouble() + 1;
            _meleeAdvantage = new Random().NextDouble() + 1;
        }

        public int SimulateBattle(List<string> team1, List<string> team2)
        {
            var character1 = _pool.GetCharacter(GetFirstCharacter(team1));
            var character2 = _pool.GetCharacter(GetFirstCharacter(team2));

            ICharacter? winner = SimulateFight(character1, character2);

            while (team1.Count > 0 && team2.Count > 0)
            {
                ICharacter? character = null;

                if (_currentWinnerId == 1)
                {
                    character = _pool.GetCharacter(GetFirstCharacter(team1));

                    winner = SimulateFight(character, winner);
                }
                else
                {
                    character = _pool.GetCharacter(GetFirstCharacter(team2));

                    winner = SimulateFight(winner, character);
                }
            }

            _pool.Release(winner);

            return _currentWinnerId;
        }

        protected ICharacter SimulateFight(ICharacter character1, ICharacter character2)
        {
            double damageCharacter1 = CalculateTotalDamage(character1);
            double damageCharacter2 = CalculateTotalDamage(character2);

            while (character1.HealthLevel > 0 && character2.HealthLevel > 0)
            {
                character2.HealthLevel -= Convert.ToInt32(damageCharacter1);

                if (character2.HealthLevel > 0)
                {
                    character1.HealthLevel -= Convert.ToInt32(damageCharacter2);
                }
            }

            if (character1.HealthLevel <= 0)
            {
                _pool.Release(character1);
                _currentWinnerId = 2;
                return character2;
            }
            else
            {
                _pool.Release(character2);
                _currentWinnerId = 1;
                return character1;
            }
        }

        protected double CalculateTotalDamage(ICharacter character)
        {
            return character.RangedDamage * _rangedAdvantage + character.MeleeDamage * _meleeAdvantage;
        }

        protected string GetFirstCharacter(List<string> team)
        {
            var chType = team.First();
            team.Remove(chType);

            return chType;
        }
    }
}