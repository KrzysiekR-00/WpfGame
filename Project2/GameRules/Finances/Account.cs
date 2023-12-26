namespace GameRules.Finances
{
    public class Account
    {
        private readonly List<Operation> _operations = new();

        public float Balance { get; private set; }

        public Operation[] OperationsHistory => _operations.ToArray();

        internal Account()
        {
            Balance = 0;
        }

        internal void AddOperation(Operation operation)
        {
            _operations.Add(operation);

            Balance += operation.Amount;
        }
    }
}
