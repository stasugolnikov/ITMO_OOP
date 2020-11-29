using Lab5.Accounts;

namespace Lab5.Operations
{
    public class WithdrawOperation : Operation
    {
        private Account _account;
        private int _sum;

        public WithdrawOperation(int id, Account account, int sum) : base(id)
        {
            _account = account;
            _sum = sum;
        }

        public override void DoOperation() => _account.Balance -= _sum;

        public override void UndoOperation() => _account.Balance += _sum;
    }
}