namespace Lab5.Accounts
{
    public abstract class Account
    {
        public int Id { get; }
        public int Balance { get; set; }

        public Account(int id, int balance)
        {
            Id = id;
            Balance = balance;
        }

        public abstract bool IsWithdrawAvaliable(int sum);
    }
}