using NUnit.Framework;
using Moq;
using Skeleton.Contracts;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsExperienceWhenTargetDies()
    {
        Hero hero = new Hero("Udaren Samolet", new Axe(10,10));
        IWeapon axe = new Axe(10, 10);
        ITarget dummy = new Dummy(10, 10);

        hero.Attack(dummy);
        Assert.That(hero.Experience, Is.EqualTo(10), "Hero doesn't gain experience when target dies");
    }

    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();

        fakeTarget.Setup(p => p.Health).Returns(0);
        fakeTarget.Setup(p => p.GiveExperience()).Returns(20);
        fakeTarget.Setup(p => p.IsDead()).Returns(true);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero("Pesho", fakeWeapon.Object);
        hero.Attack(fakeTarget.Object);
        Assert.That(hero.Experience, Is.EqualTo(20));
    }

}