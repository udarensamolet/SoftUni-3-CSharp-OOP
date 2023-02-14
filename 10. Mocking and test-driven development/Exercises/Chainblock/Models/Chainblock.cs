using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Models
{
    public class Chainblock : IChainblock
    {
        private List<ITransaction> transactions = new List<ITransaction>();

        public Chainblock()
        {
            transactions = new List<ITransaction>();
        }

        public IReadOnlyCollection<ITransaction> Transactions => transactions.AsReadOnly();

        public int Count => Transactions.Count;

        public void Add(ITransaction tx)
        {
            if (transactions.Contains(tx))
            {
                throw new ArgumentException();
            }
            transactions.Add(tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            var targetTransaction = transactions.FirstOrDefault(t => t.Id == id);
            if (targetTransaction == null)
            {
                throw new ArgumentException();
            }
            targetTransaction.Status = newStatus;
        }

        public bool Contains(int id)
        {
            var targetTransaction = Transactions.FirstOrDefault(t => t.Id == id);
            if (targetTransaction == null)
            {
                return false;
            }
            return true;
        }

        public bool Contains(ITransaction tx)
            => this.Contains(tx.Id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            var targetTransactions = Transactions
                .Where(t => t.Amount >= lo && t.Amount <= hi)
                .ToList();

            return targetTransactions;
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            var targetTransactions = Transactions
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (targetTransactions.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return targetTransactions;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            Dictionary<string, int> receiversTransactions = new Dictionary<string, int>();
            var result = Transactions
                .Where(t => t.Status == status)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            foreach (var transaction in result)
            {
                if (!receiversTransactions.ContainsKey(transaction.To))
                {
                    receiversTransactions.Add(transaction.To, 0);
                }
                receiversTransactions[transaction.To]++;
            }

            var resultList = new List<string>();

            foreach (var transaction in receiversTransactions.OrderByDescending(s => s.Value))
            {
                for (int i = 0; i < transaction.Value; i++)
                {
                    resultList.Add(transaction.Key);
                }
            }
            return resultList;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            Dictionary<string, int> sendersTransactions = new Dictionary<string, int>();
            var result = Transactions
                .Where(t => t.Status == status)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            foreach (var transaction in result)
            {
                if (!sendersTransactions.ContainsKey(transaction.From))
                {
                    sendersTransactions.Add(transaction.From, 0);
                }
                sendersTransactions[transaction.From]++;
            }

            var resultList = new List<string>();

            foreach (var transaction in sendersTransactions.OrderByDescending(s => s.Value))
            {
                for (int i = 0; i < transaction.Value; i++)
                {
                    resultList.Add(transaction.Key);
                }
            }
            return resultList;
        }

        public ITransaction GetById(int id)
        {
            var transaction = Transactions.FirstOrDefault(t => t.Id == id);
            if (transaction == null)
            {
                throw new InvalidOperationException();
            }
            return transaction;
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var targetTransactions = Transactions
                .Where(t => t.To == receiver && (t.Amount >= lo && t.Amount < hi))
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (targetTransactions.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return targetTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var targetTransactions = Transactions
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (targetTransactions.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return targetTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var targetTransactions = Transactions
                .Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (targetTransactions.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return targetTransactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var targetTransactions = Transactions
                .Where(t => t.From == sender)
                .ToList();
            if (targetTransactions.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return targetTransactions.OrderByDescending(t => t.Amount).ToList();

        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            var result = Transactions
                .Where(t => t.Status == status)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return result.OrderByDescending(t => t.Amount);
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            var targetTransactions = Transactions
                .Where(t => t.Status == status && t.Amount <= amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            return targetTransactions;
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in Transactions)
            {
                yield return transaction;
            }
        }

        public void RemoveTransactionById(int id)
        {
            var targetTransaction = Transactions.FirstOrDefault(t => t.Id == id);
            if (targetTransaction == null)
            {
                throw new ArgumentException();
            }
            transactions.Remove(targetTransaction);
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
