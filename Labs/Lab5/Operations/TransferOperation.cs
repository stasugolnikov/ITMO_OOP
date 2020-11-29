using Lab5.Accounts;

namespace Lab5.Operations
{
    public class TransferOperation : Operation
    {
        private Account _sender;
        private Account _receiver;
        private int _sum;

        public TransferOperation(int id, Account sender, Account receiver, int sum) : base(id)
        {
            _sender = sender;
            _receiver = receiver;
            _sum = sum;
        }

        public override void DoOperation()
        {
            _sender.Balance -= _sum;
            _receiver.Balance += _sum;
        }

        public override void UndoOperation()
        {
            _sender.Balance += _sum;
            _receiver.Balance -= _sum;
        }
    }
}