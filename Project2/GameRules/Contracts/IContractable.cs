namespace GameRules.Contracts
{
    public interface IContractable
    {
        public Contract? Contract { get; }

        internal void SetContract(Contract? contract);

        internal int ExpectedEmployerReputation { get; }
    }
}
