using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLoosesHealthIfAttacked()
    {
        Dummy dummy = new Dummy(10, 10);
        dummy.TakeAttack(7);
        Assert.That(dummy.Health, Is.EqualTo(3), "Dummy doesn't loose health when attacked!");
    }

    [Test]
    public void DummyThrowsExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(-3, 0);
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
    }

    [Test]
    public void DummyCanGiveExperience()
    {
        Dummy dummy = new Dummy(-5, 10);
        Assert.That(dummy.GiveExperience(), Is.EqualTo(10), "Dummy doesn't give experience!");
    }

    [Test]
    public void DummyCannotGiveExperience()
    {
        Dummy dummy = new Dummy(10, 10);
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
