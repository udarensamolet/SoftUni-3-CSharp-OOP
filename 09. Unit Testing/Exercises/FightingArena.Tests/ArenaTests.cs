using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_CreatesCorrectInstance_Test()
        {
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Enroll_WarriorsCountIncreases_Test()
        {
            Warrior warrior = new Warrior("udarensamolet", 50, 50);
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void Enroll_ThrowsExceptionWarriorAlreadyEnrolled_Test()
        {
            Warrior warrior = new Warrior("udarensamolet", 50, 50);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        public void Fight_ThrowsExceptionMissingAttacked_Test()
        {
            Warrior warrior = new Warrior("udarensamolet", 50, 50);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() =>arena.Fight("udarensamolet", "missing"));
        }

        [Test]
        public void Fight_ThrowsExceptionMissingAttacker_Test()
        {
            Warrior warrior = new Warrior("udarensamolet", 50, 50);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("missing", "udarensamolet"));
        }

    }
}
