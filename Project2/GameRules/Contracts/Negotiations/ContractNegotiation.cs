namespace GameRules.Contracts.Negotiations
{
    public abstract class ContractNegotiation
    {
        protected readonly Employer _employer;
        protected readonly IContractable _contractable;
        protected readonly int _currentTurn;

        public int MinContractLength { get; protected set; } = 1;
        public int MaxContractLength { get; private set; } = 20;

        public ContractNegotiation(Employer employer, IContractable contractable, int currentTurn)
        {
            _employer = employer;
            _contractable = contractable;
            _currentTurn = currentTurn;
        }

        public float GetContractableExpectedWage(int proposedContractLengthInTurns)
        {
            if (proposedContractLengthInTurns < MinContractLength) return float.MaxValue;
            if (proposedContractLengthInTurns > MaxContractLength) return float.MaxValue;

            return WageCalculator.GetWage(_contractable.ExpectedEmployerReputation, _employer.Reputation, proposedContractLengthInTurns);
        }

        public abstract void SignContract(int proposedContractLengthInTurns);
    }
}
