using Skeleton.Contracts;

public class Hero
{
    private string _name;
    private int _experience;
    private Axe _weapon;

    public Hero(string name, IWeapon weapon)
    {
        _name = name;
        _experience = 0;
        _weapon = new Axe(10, 10);
    }

    public string Name
    {
        get { return _name; }
    }

    public int Experience
    {
        get { return _experience; }
    }

    public Axe Weapon
    {
        get { return _weapon; }
    }

    public void Attack(ITarget target)
    {
        _weapon.Attack(target);

        if (target.IsDead())
        {
            _experience += target.GiveExperience();
        }
    }
}
