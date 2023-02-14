using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("udarensamolet", 5, 35);
        }

        [Test]
        public void Ctor_CreatesCorrectInstance()
        {
            Assert.AreEqual("udarensamolet", warrior.Name);
            Assert.AreEqual(5, warrior.Damage);
            Assert.AreEqual(5, warrior.HP);
        }

        [Test]
        [TestCase(" ", 5, 5)]
        [TestCase(null, 5, 5)]
        [TestCase("udarensamolet", -5, 5)]
        [TestCase("udarensamolet", 0, 5)]
        [TestCase("udarensamolet", 5, -3)]
        public void Ctor_ThrowsExceptionInvalidData(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]
        public void Attack_ThrowsExceptionAttackingHpIsLessThanNeeded_Test()
        {
            Warrior attackingWarrior = new Warrior("udarensamolet1", 5, 5);
            Warrior attackedWarrior = new Warrior("udarensamolet2", 5, 35);
            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(attackedWarrior));
        }

        [Test]
        public void Attack_ThrowsExceptionAttackedHpIsLessThanNeeded_Test()
        {
            Warrior attackingWarrior = new Warrior("udarensamolet1", 50, 35);
            Warrior attackedWarrior = new Warrior("udarensamolet2", 5, 20);
            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(attackedWarrior));
        }

        [Test]
        public void Attack_ThrowsExceptionAttackingHpIsLessThanDamage_Test()
        {
            Warrior attackingWarrior = new Warrior("udarensamolet1", 50, 35);
            Warrior attackedWarrior = new Warrior("udarensamolet2", 70, 40);
            Assert.Throws<InvalidOperationException>(() => attackingWarrior.Attack(attackedWarrior));
        }

        [Test]
        public void Attack_AttackingHpDecreases_Test()
        {
            Warrior attackingWarrior = new Warrior("udarensamolet1", 150, 100);
            Warrior attackedWarrior = new Warrior("udarensamolet2", 70, 40);
            attackingWarrior.Attack(attackedWarrior);
            Assert.AreEqual(30, attackingWarrior.HP);
        }

        [Test]
        public void Attack_AttackedHpDecreasesToZero_Test()
        {
            Warrior attackingWarrior = new Warrior("udarensamolet1", 150, 100);
            Warrior attackedWarrior = new Warrior("udarensamolet2", 70, 40);
            attackingWarrior.Attack(attackedWarrior);
            Assert.AreEqual(0, attackedWarrior.HP);
        }

        [Test]
        public void Attack_AttackedHpDecreases_Test()
        {
            Warrior attackingWarrior = new Warrior("udarensamolet1", 130, 100);
            Warrior attackedWarrior = new Warrior("udarensamolet2", 70, 140);
            attackingWarrior.Attack(attackedWarrior);
            Assert.AreEqual(10, attackedWarrior.HP);
        }
    }
}