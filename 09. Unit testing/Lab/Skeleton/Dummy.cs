using Skeleton.Contracts;
using System;

public class Dummy : ITarget
{
    private int _health;
    private int _experience;

    public Dummy(int health, int experience)
    {
        _health = health;
        _experience = experience;
    }

    public int Health 
    {
        get { return _health; }
    }

    public void TakeAttack(int attackPoints)
    {
        if (IsDead())
        {
            throw new InvalidOperationException("Dummy is dead.");
        }

        _health -= attackPoints;
    }

    public int GiveExperience()
    {
        if (!IsDead())
        {
            throw new InvalidOperationException("Target is not dead.");
        }

        return _experience;
    }

    public bool IsDead()
    {
        return _health <= 0;
    }
}