namespace Lab5.Accounts
{
    public abstract class Account
    {
        public int Id { get; }
        public double Balance { get; set; }

        public Account(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }

        public abstract bool IsWithdrawAvaliable(int sum);
    }
}