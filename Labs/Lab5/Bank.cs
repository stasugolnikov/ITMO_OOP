using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Lab5.Accounts;
using Lab5.Operations;

namespace Lab5
{
    public class Bank
    {
        private double _debitPercentage;
        private List<(int, double)> _depositPercentages;
        private double _creditComission;
        private int _creditLimit;
        private double _notCertifiedClientLimit;
        private List<Operation> _operations;
        private Dictionary<Client, List<Account>> _clientAccounts;
        private static int _idCounter = 0;

        public Bank(double debitPercentage, List<(int, double)> depositPercentages,
            double creditComission, int creditLimit, double notCertifiedClientLimit)
        {
            _debitPercentage = debitPercentage;
            _depositPercentages = depositPercentages;
            _creditComission = creditComission;
            _creditLimit = creditLimit;
            _notCertifiedClientLimit = creditComission;
            _operations = new List<Operation>();
            _clientAccounts = new Dictionary<Client, List<Account>>();
        }

        public void AddClient(Client client) => _clientAccounts[client] = new List<Account>();

        public void CreateDebitAccount(Client client, int sum)
        {
            if (!_clientAccounts.ContainsKey(client)) /* throw ex */ ;
            _clientAccounts[client].Add(new DebitAccount(_idCounter++, sum, _debitPercentage));
        }

        public void CreateDepositAccount(Client client, int sum, int period)
        {
            if (!_clientAccounts.ContainsKey(client)) /* throw ex */ ;
            double percentage = 0;
            foreach (var depositPercentage in _depositPercentages)
            {
                if (sum < depositPercentage.Item1)
                {
                    percentage = depositPercentage.Item2;
                    break;
                }
            }

            if (percentage == 0) percentage = _depositPercentages[^1].Item2;
            _clientAccounts[client].Add(new DepositAccount(_idCounter++, sum, percentage, period));
        }

        public void CreateCreditAccount(Client client, int sum)
        {
            if (!_clientAccounts.ContainsKey(client)) /* throw ex */ ;
            _clientAccounts[client].Add(new CreditAccount(_idCounter++, sum,
                _creditLimit, _creditComission));
        }

        private bool CheckClient(Client client) =>
            !String.IsNullOrEmpty(client.Adress) || !String.IsNullOrEmpty(client.Passport);


        private bool TryGetClientAccount(int id, out Client client, out Account acc)
        {
            foreach (var clientAccount in _clientAccounts)
            {
                foreach (var account in clientAccount.Value)
                {
                    if (account.Id == id)
                    {
                        client = clientAccount.Key;
                        acc = account;
                        return true;
                    }
                }
            }

            client = default;
            acc = default;
            return false;
        }

        public void AddMoney(int id, int sum)
        {
            if (!TryGetClientAccount(id, out var client, out var account)) /* throw ex */ ;
            var addOperation = new AddOperation(_idCounter++, account, sum);
            addOperation.DoOperation();
            _operations.Add(addOperation);
        }

        public void WithdrawMoney(int id, int sum)
        {
            if (!TryGetClientAccount(id, out var client, out var account) && !CheckClient(client) &&
                sum > _notCertifiedClientLimit && !account.IsWithdrawAvaliable(sum)) /* throw ex */ ;
            var withdrawOperation = new WithdrawOperation(_idCounter++, account, sum);
            withdrawOperation.DoOperation();
            _operations.Add(withdrawOperation);
        }

        public void TransferMoney(int id1, int id2, int sum)
        {
            if (!TryGetClientAccount(id1, out var client1, out var account1)
                && !CheckClient(client1) && sum > _notCertifiedClientLimit &&
                !account1.IsWithdrawAvaliable(sum)) /* throw ex */ ;
            if (!TryGetClientAccount(id2, out var client2, out var account2)) /* throw ex */ ;

            var transferOperation = new TransferOperation(_idCounter++, account1, account2, sum);
            transferOperation.DoOperation();
            _operations.Add(transferOperation);
        }

        public void UndoOperation(int id)
        {
            int pos = _operations.FindIndex(operation => operation.Id == id);
            if (pos == -1) /* throw ex */ ;
            _operations[pos].UndoOperation();
        }
    }
}