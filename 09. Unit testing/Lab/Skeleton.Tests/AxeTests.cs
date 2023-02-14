using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{

    [Test]
    public void AxeLoosesDurabitlyAfterAttack()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);
        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(5), "Axe Durability doesn't change after attack");
    }

    [Test]
    public void AxeLoosesDurabilityWhenBroken()
    {
        Axe axe = new Axe(10, -5);
        Dummy dummy = new Dummy(10, 10);
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}