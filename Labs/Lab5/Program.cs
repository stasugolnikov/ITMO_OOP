using System;
using System.Collections.Generic;
using Lab5.Accounts;
using Lab5.ClientCreation;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Client, List<Account>> ClientAccounts = new Dictionary<Client, List<Account>>();
            Client c1 = new Client();
            Client c2 = new Client();
            ClientAccounts[c1] = new List<Account>();
            ClientAccounts[c1].Add(new CreditAccount(1,1,1,1));
            ClientAccounts[c1].Add(new DepositAccount(2,1,1,1));
            
            ClientAccounts[c2] = new List<Account>();
            ClientAccounts[c2].Add(new CreditAccount(1,1,1,1));
            ClientAccounts[c2].Add(new DepositAccount(2,1,1,1));

            Console.WriteLine();
        }
    }
}