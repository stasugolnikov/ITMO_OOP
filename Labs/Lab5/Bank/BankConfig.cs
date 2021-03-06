using System.Collections.Generic;
using Lab5.Accounts;
using Lab5.ClientCreation;
using Lab5.Operations;

namespace Lab5.Bank
{
    public struct BankConfig
    {
        public double DebitPercentage { get; }
        public List<(int sum, double percentage)> DepositPercentages { get; }
        public double CreditComission { get; }
        public int CreditLimit { get; }
        public double NotCertifiedClientLimit { get; }
        public List<Operation> Operations { get; }
        public List<Client> Clients { get; }
        public Dictionary<int, List<Account>> ClientIdAccounts { get; }
        
        public BankConfig(double debitPercentage, List<(int, double)> depositPercentages,
            double creditComission, int creditLimit, double notCertifiedClientLimit)
        {
            DebitPercentage = debitPercentage;
            DepositPercentages = depositPercentages;
            DepositPercentages.Sort();
            CreditComission = creditComission;
            CreditLimit = creditLimit;
            NotCertifiedClientLimit = notCertifiedClientLimit;
            Operations = new List<Operation>();
            Clients = new List<Client>();
            ClientIdAccounts = new Dictionary<int, List<Account>>();
        }

    }
}