using Lab5.Accounts;

namespace Lab5.Operations
{
    public class AddOperation : Operation
    {
        private Account _account;
        private int _sum;

        public AddOperation(int id, Account account, int sum) : base(id)
        {
            _account = account;
            _sum = sum;
        }

        public override void DoOperation() => _account.Balance += _sum;

        public override void UndoOperation() => _account.Balance -= _sum;
    }
}