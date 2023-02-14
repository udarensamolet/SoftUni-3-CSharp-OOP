using System;

namespace FightingArena
{
    public class Warrior
    {
        private const int MinAttackHp = 30;

        private string _name;
        private int _damage;
        private int _hp;

        public Warrior(string name, int damage, int hp)
        {
            Name = name;
            Damage = damage;
            Hp = hp;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name should not be empty or whitespace!");
                }

                _name = value;
            }
        }

        public int Damage
        {
            get
            {
                return _damage;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Damage value should be positive!");
                }

                _damage = value;
            }
        }

        public int Hp
        {
            get
            {
                return _hp;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("HP should not be negative!");
                }

                _hp = value;
            }
        }

        public void Attack(Warrior warrior)
        {
            if (Hp <= MinAttackHp)
            {
                throw new InvalidOperationException("Your HP is too low in order to attack other warriors!");
            }

            if (warrior.Hp <= MinAttackHp)
            {
                throw new InvalidOperationException($"Enemy HP must be greater than {MinAttackHp} in order to attack him!");
            }

            if (Hp < warrior.Damage)
            {
                throw new InvalidOperationException($"You are trying to attack too strong enemy");
            }

            Hp -= warrior.Damage;

            if (Damage > warrior.Hp)
            {
                warrior.Hp = 0;
            }
            else
            {
                warrior.Hp -= Damage;
            }
        }
    }
}
