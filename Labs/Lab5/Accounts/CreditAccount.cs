using System;

namespace Lab5.Accounts
{
    public class CreditAccount : Account
    {
        public int Limit { get; }
        public double Comission { get; }
        private double _comissionSum = 0;

        public CreditAccount(int id, int balance, int limit, double comission) : base(id, balance)
        {
            Limit = limit;
            Comission = comission;
        }
        
        public void CalculateComission() => _comissionSum += Balance * Comission / 100;
        
        public void SubtractComission()
        {
            Balance -= (int)_comissionSum;
            _comissionSum = 0;
        }


        public override bool IsWithdrawAvaliable(int sum) => Math.Abs(Balance - sum) < Limit;
    }
}