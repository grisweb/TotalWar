using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalWar.Characters;

namespace TotalWar
{
    internal class CharactersObjectPool
    {
        private List<ICharacter> _pool;

        private int _maxCount = int.MaxValue;

        public CharactersObjectPool()
        {
            _pool = new List<ICharacter>();
        }

        public int Count => _pool.Count;

        public ICharacter GetCharacter(string type)
        {
            ICharacter? thisObject = RemoveCharacter(type);

            if (thisObject != null)
            {
                return thisObject;
            }

            return CreateCharacter(type);
        }

        private ICharacter? RemoveCharacter(string type)
        {
            if (_pool.Count > 0)
            {
                ICharacter? thisObject = _pool.Find(character => character.Race == type);

                if(thisObject != null)
                {
                    _pool.Remove(thisObject);
                }
                

                return thisObject;
            }
            else
            {
                return null;
            }
        }

        private ICharacter CreateCharacter(string type)
        {
            ICharacter? thisObject = null;

            switch (type)
            {
                case "Elf":
                    thisObject = new Elf();
                    break;
                case "Gnome":
                    thisObject = new Gnome();
                    break;
                default:
                    throw new Exception("Неверный тип персонажа!");
            }

            return thisObject;
        }

        public void Release(ICharacter character)
        {
            character.HealthLevel = ICharacter.maxHealthLevel;
            _pool.Add(character);
        }
    }
}
