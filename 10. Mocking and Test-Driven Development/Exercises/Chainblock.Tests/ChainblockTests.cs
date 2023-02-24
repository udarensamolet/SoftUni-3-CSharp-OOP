using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Chainblock.Models;
using System.Linq;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private Chainblock.Models.Chainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock.Models.Chainblock();
        }

        [Test]
        public void Add_IncreasesCount()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);

            chainblock = new Models.Chainblock()
            {
                transaction1,
                transaction2
            };

            Assert.AreEqual(2, chainblock.Count);
        }

        [Test]
        public void Add_ThrowsException()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            Assert.Throws<ArgumentException>(() => chainblock.Add(transaction1));
        }

        [Test]
        public void ContainsId_ReturnsTrue()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var result = chainblock.Contains(1);

            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsId_ReturnsFalse()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var result = chainblock.Contains(3);

            Assert.IsFalse(result);
        }

        [Test]
        public void ContainsTransaction_ReturnsTrue()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var result = chainblock.Contains(transaction1);

            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var result = chainblock.Contains(transaction3);

            Assert.IsFalse(result);
        }

        [Test]
        public void ChangeTransactionStatus_ValidIdChangesIdOfCorrectTransaction()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.ChangeTransactionStatus(1, TransactionStatus.Unauthorized);
            string newTransactionStatus = "Unauthorized";

            Assert.AreEqual(newTransactionStatus, transaction1.Status.ToString());
        }

        [Test]
        public void ChangeTransactionStatus_ThrowsExceptionInvalidId()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(3, TransactionStatus.Unauthorized));
        }

        [Test]
        public void RemoveTransactionById_ValidIdRemovesCorrectTransaction()
        {

            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.RemoveTransactionById(1);

            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void RemoveTransactionById_ThrowsExceptionInvalidId()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            Assert.Throws<ArgumentException>(() => chainblock.RemoveTransactionById(3));
        }

        [Test]
        public void GetById_ValidIdReturnCorrectTransaction()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            var result = chainblock.GetById(1);

            int expectedId = 1;
            string expectedTransactionStatus = "Successfull";
            string expectedFrom = "udaren";
            string expectedTo = "samolet";
            double expctedAmount = 5;

            Assert.AreEqual(expectedId, result.Id);
            Assert.AreEqual(expectedTransactionStatus, result.Status.ToString());
            Assert.AreEqual(expectedFrom, result.From);
            Assert.AreEqual(expectedTo, result.To);
            Assert.AreEqual(expctedAmount, result.Amount);
        }

        [Test]
        public void GetById_ThrowsExceptionInvalidId()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 5);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(3));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsOrderedListByGivenStatus()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "samolet", "udaren", 7);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "samolet", "udaren", 9);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            var expectedResultList = new Chainblock.Models.Chainblock()
            {
                transaction1, transaction3, transaction5
            };
            var expectedResultListOrdered = expectedResultList.OrderByDescending(t => t.Amount).ToList();

            var actualResultList = chainblock
                .GetByTransactionStatus(TransactionStatus.Successfull)
                .ToList();
            var actualResultListOrdered = actualResultList.OrderByDescending(t => t.Amount).ToList();

            Assert.AreEqual(expectedResultList.Count, actualResultList.Count);
            Assert.AreEqual(expectedResultListOrdered[0].Id, actualResultListOrdered[0].Id);
        }

        [Test]
        public void GetTransactionStatus_ThrowsExceptionWhenNotFoundStatus()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "samolet", "udaren", 7);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "samolet", "udaren", 9);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ReturnsCorrectSenders()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Unauthorized, "udaren", "udaren", 9);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<string> expectedResult = new List<string>()
            {
                "udaren", "udaren", "samolet"
            };

            var actualResult = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull).ToList();
            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i]);
            }
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsExceptionNoTransaction()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Unauthorized, "udaren", "udaren", 9);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ReturnsCorrectReceivers()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Unauthorized, "udaren", "udaren", 9);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);


            List<string> expectedResult = new List<string>()
            {
                "samolet", "samolet", "udaren"
            };

            var actualResult = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull).ToList();
            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], actualResult[i]);
            }
        }

        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsExceptionNoTransactio()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Unauthorized, "udaren", "udaren", 9);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsCorrectTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Unauthorized, "udaren", "udaren", 9);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<Transaction> expectedResult = new List<Transaction>()
            {
                transaction1, transaction5, transaction3
            };

            var actualResult = chainblock.GetBySenderOrderedByAmountDescending("udaren").ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            Assert.AreEqual(expectedResult[0].Id, actualResult[0].Id);
            Assert.AreEqual(expectedResult[1].Id, actualResult[1].Id);
            Assert.AreEqual(expectedResult[2].Id, actualResult[2].Id);
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsExceptionWhenNoSender()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Unauthorized, "udaren", "udaren", 9);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("test"));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsCorrectlySorted()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Failed, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 11);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Unauthorized, "udaren", "udaren", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<Transaction> expectedResult = new List<Transaction>()
            {
                transaction3,
                transaction5,
                transaction2,
                transaction4,
                transaction1
            };

            var actualResult = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            Assert.AreEqual(expectedResult[0].Id, actualResult[0].Id);
            Assert.AreEqual(expectedResult[1].Id, actualResult[1].Id);
            Assert.AreEqual(expectedResult[2].Id, actualResult[2].Id);
            Assert.AreEqual(expectedResult[3].Id, actualResult[3].Id);
            Assert.AreEqual(expectedResult[4].Id, actualResult[4].Id);
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ThrowsExceptionWhenEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllOrderedByAmountDescendingThenById());
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsCorrectAmountAndTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 9);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "udaren", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<Transaction> expectedResult = new List<Transaction>()
            {
                transaction2,
                transaction4,
                transaction1,
            };

            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, 8).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            Assert.AreEqual(expectedResult[0].Id, actualResult[0].Id);
            Assert.AreEqual(expectedResult[1].Id, actualResult[1].Id);
            Assert.AreEqual(expectedResult[2].Id, actualResult[2].Id);
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsNull()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Successfull, "udaren", "samolet", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "samolet", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Successfull, "udaren", "samolet", 9);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Successfull, "samolet", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "udaren", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<Transaction> expectedResult = new List<Transaction>();

            var actualResult = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Aborted, 8).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "The problem is here");
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ReturnsCorrectCountAndTransactions()
        {

            Transaction transaction1 = new Transaction(1, TransactionStatus.Unauthorized, "udaren", "samolet", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "udaren", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "udaren", "samolet", 9);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "udaren", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "udaren", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);


            List<Transaction> expectedResult = new List<Transaction>()
            {
                transaction5,
                transaction3,
            };

            var actualResult = chainblock.GetBySenderAndMinimumAmountDescending("udaren", 8).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            Assert.AreEqual(expectedResult[0].Id, actualResult[0].Id);
            Assert.AreEqual(expectedResult[1].Id, actualResult[1].Id);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsExceptionWhenNoTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Unauthorized, "udaren", "samolet", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "udaren", "udaren", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "udaren", "samolet", 9);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "udaren", "udaren", 5);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "udaren", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("samolet", 8));
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderAndMinimumAmountDescending("udaren", 15));
        }

        [Test]
        public void GetByReceiverAndAmountRange_ReturnsCorrectAmountAndTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Unauthorized, "udaren", "samolet", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "udaren", "samolet", 5);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "udaren", "samolet", 7);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "samolet", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<Transaction> expectedResult = new List<Transaction>()
            {
                transaction2,
                transaction4,
                transaction3,
            };

            var actualResult = chainblock.GetByReceiverAndAmountRange("samolet", 5, 8).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            Assert.AreEqual(expectedResult[0].Id, actualResult[0].Id);
            Assert.AreEqual(expectedResult[1].Id, actualResult[1].Id);
            Assert.AreEqual(expectedResult[2].Id, actualResult[2].Id);
        }

        [Test]
        public void GetByReceiverAndAmountRange_ThrowsExceptionWhenNoTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Unauthorized, "udaren", "samolet", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "udaren", "samolet", 5);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "udaren", "samolet", 7);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "samolet", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("udaren", 5, 8));
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverAndAmountRange("samolet", 13, 15));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsCorrectCountAndTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Unauthorized, "udaren", "udaren", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "udaren", "samolet", 5);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "udaren", "samolet", 7);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "udaren", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<Transaction> expectedResult = new List<Transaction>()
            {
                transaction2,
                transaction4,
                transaction3,
            };

            var actualResult = chainblock.GetByReceiverOrderedByAmountThenById("samolet").ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            Assert.AreEqual(expectedResult[0].Id, actualResult[0].Id);
            Assert.AreEqual(expectedResult[1].Id, actualResult[1].Id);
            Assert.AreEqual(expectedResult[2].Id, actualResult[2].Id);
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsExceptionWhenNoTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Unauthorized, "udaren", "samolet", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "udaren", "samolet", 5);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "udaren", "samolet", 7);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "samolet", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("udaren"));
        }


        [Test]
        public void GetAllInAmountRange_ReturnsCorrectCountAndTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Unauthorized, "udaren", "udaren", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "udaren", "samolet", 5);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "udaren", "samolet", 7);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "udaren", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<Transaction> expectedResult = new List<Transaction>()
            {
                transaction1,
                transaction2,
                transaction3,
                transaction4,
            };

            var actualResult = chainblock.GetAllInAmountRange(3, 7).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);

            Assert.AreEqual(expectedResult[0].Id, actualResult[0].Id);
            Assert.AreEqual(expectedResult[1].Id, actualResult[1].Id);
            Assert.AreEqual(expectedResult[2].Id, actualResult[2].Id);
            Assert.AreEqual(expectedResult[3].Id, actualResult[3].Id);
        }

        [Test]
        public void GetAllInAmountRange_ReturnsNullWhenNoTransactions()
        {
            Transaction transaction1 = new Transaction(1, TransactionStatus.Unauthorized, "udaren", "udaren", 3);
            Transaction transaction2 = new Transaction(2, TransactionStatus.Successfull, "udaren", "samolet", 7);
            Transaction transaction3 = new Transaction(3, TransactionStatus.Aborted, "udaren", "samolet", 5);
            Transaction transaction4 = new Transaction(4, TransactionStatus.Failed, "udaren", "samolet", 7);
            Transaction transaction5 = new Transaction(5, TransactionStatus.Successfull, "udaren", "udaren", 11);
            chainblock.Add(transaction1);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);
            chainblock.Add(transaction5);

            List<Transaction> expectedResult = new List<Transaction>();

            var actualResult = chainblock.GetAllInAmountRange(13, 15).ToList();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);

        }
    }
}