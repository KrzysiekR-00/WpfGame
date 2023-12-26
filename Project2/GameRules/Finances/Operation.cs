namespace GameRules.Finances
{
    public readonly struct Operation
    {
        public OperationType OperationType { get; }
        public int Turn { get; }
        public float Amount { get; }

        internal Operation(OperationType operationType, int turn, float amount)
        {
            OperationType = operationType;
            Turn = turn;
            Amount = amount;
        }
    }
}
