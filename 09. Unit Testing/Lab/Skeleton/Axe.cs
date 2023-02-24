using Skeleton.Contracts;
using System;

// Axe durability drops with 5 
public class Axe : IWeapon
{
    private int _attackPoints;
    private int _durabilityPoints;

    public Axe(int attack, int durability)
    {
        _attackPoints = attack;
        _durabilityPoints = durability;
    }

    public int AttackPoints
    {
        get { return _attackPoints; }
    }

    public int DurabilityPoints
    {
        get { return _durabilityPoints; }
    }

    public void Attack(ITarget target)
    {
        if (_durabilityPoints <= 0)
        {
            throw new InvalidOperationException("Axe is broken.");
        }

        target.TakeAttack(_attackPoints);
        _durabilityPoints -= 5;
    }
}
