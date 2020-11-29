namespace Lab5.Accounts
{
    public class DepositAccount : Account
    {
        public double Persentage { get; }
        public int Period { get; }
        private double _profit = 0;
        
        public DepositAccount(int id, int balance, double persentage, int period) : base(id, balance)
        {
            Persentage = persentage;
            Period = period;
        }

        public void CalculateProfit() => _profit += Balance * Persentage / 100;
        
        public void PayProfit()
        {
            Balance += (int)_profit;
            _profit = 0;
        }

        public override bool IsWithdrawAvaliable(int sum) => Balance >= sum && Period == 0;
    }
}