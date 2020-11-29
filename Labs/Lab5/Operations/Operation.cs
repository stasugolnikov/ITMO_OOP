namespace Lab5.Operations
{
    public abstract class Operation
    {
        public int Id { get; }

        public Operation(int id)
        {
            Id = id;
        }
        
        public abstract void DoOperation();
        public abstract void UndoOperation();
    }
}