namespace Lab5.Accounts
{
    public class DebitAccount : Account
    {
        public double Persentage { get; }
        private double _profit = 0;

        public DebitAccount(int id, int balance, double persentage) : base(id, balance)
        {
            Persentage = persentage;
        }

        public void CalculateProfit() => _profit += Balance * Persentage / 100;

        public void PayProfit()
        {
            Balance += (int) _profit;
            _profit = 0;
        }

        public override bool IsWithdrawAvaliable(int sum) => Balance >= sum;
    }
}