using System;
using System.Collections.Generic;
using Lab5.Accounts;
using Lab5.Operations;
using Lab5.ClientCreation;

namespace Lab5.Bank
{
    public class Bank
    {
        public BankConfig BankConfig { get; }
        private static int _idCounter = 0;

        public Bank(double debitPercentage, List<(int, double)> depositPercentages,
            double creditComission, int creditLimit, double notCertifiedClientLimit)
        {
            BankConfig = new BankConfig(debitPercentage, depositPercentages, creditComission, creditLimit,
                notCertifiedClientLimit);
        }

        public void AddClient(Client client) => BankConfig.ClientAccounts[client] = new List<Account>();

        public DebitAccount CreateDebitAccount(int sum)
        {
            return new DebitAccount(_idCounter++, sum, BankConfig.DebitPercentage);
        }


        public DepositAccount CreateDepositAccount(int sum, int period)
        {
            double percentage = 0;
            foreach (var depositPercentage in BankConfig.DepositPercentages)
            {
                if (sum < depositPercentage.sum)
                {
                    percentage = depositPercentage.percentage;
                    break;
                }
            }

            if (percentage == 0) percentage = BankConfig.DepositPercentages[^1].percentage;
            return new DepositAccount(_idCounter++, sum, percentage, period);
        }

        public CreditAccount CreateCreditAccount(int sum)
        {
            return new CreditAccount(_idCounter++, sum, BankConfig.CreditLimit, BankConfig.CreditComission);
        }

        public void AddAccount(Client client, Account account)
        {
            if (!BankConfig.ClientAccounts.ContainsKey(client))
                throw new NonExistentIdException("Client Id " + client.Id + " don't exists");
            BankConfig.ClientAccounts[client].Add(account);
        }

        private bool CheckClient(Client client) =>
            !String.IsNullOrEmpty(client.Adress) || !String.IsNullOrEmpty(client.Passport);


        private bool TryGetClientAccount(int id, out Client client, out Account acc)
        {
            foreach (var clientAccount in BankConfig.ClientAccounts)
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
            if (!TryGetClientAccount(id, out var client, out var account))
                throw new NonExistentIdException("Account Id " + account.Id + " don't exists");
            var addOperation = new AddOperation(_idCounter++, account, sum);
            addOperation.DoOperation();
            BankConfig.Operations.Add(addOperation);
        }

        public void WithdrawMoney(int id, int sum)
        {
            if (!TryGetClientAccount(id, out var client, out var account)
                && !CheckClient(client)
                && sum > BankConfig.NotCertifiedClientLimit
                && !account.IsWithdrawAvaliable(sum))
                throw new UnavaliableOperationException("Can't withdraw from account " + account.Id);
            
            var withdrawOperation = new WithdrawOperation(_idCounter++, account, sum);
            withdrawOperation.DoOperation();
            BankConfig.Operations.Add(withdrawOperation);
        }

        public void TransferMoney(int id1, int id2, int sum)
        {
            Account account2 = null;
            Client client2 = null;
            if (!TryGetClientAccount(id1, out var client1, out var account1)
                && !TryGetClientAccount(id2, out client2, out account2)
                && !CheckClient(client1)
                && sum > BankConfig.NotCertifiedClientLimit
                && !account1.IsWithdrawAvaliable(sum)
            ) 
                throw new UnavaliableOperationException("Can't transfer from account " + account1.Id);


            var transferOperation = new TransferOperation(_idCounter++, account1, account2, sum);
            transferOperation.DoOperation();
            BankConfig.Operations.Add(transferOperation);
        }

        public void UndoOperation(int id)
        {
            int pos = BankConfig.Operations.FindIndex(operation => operation.Id == id);
            if (pos == -1) /* throw ex */ ;
            BankConfig.Operations[pos].UndoOperation();
        }
    }
}