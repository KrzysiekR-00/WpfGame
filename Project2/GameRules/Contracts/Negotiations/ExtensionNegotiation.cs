namespace GameRules.Contracts.Negotiations
{
    public class ExtensionNegotiation : ContractNegotiation
    {
        private readonly Contract _contractToExtend;

        public ExtensionNegotiation(Contract contractToExtend, int currentTurn)
            : base(contractToExtend.Employer, contractToExtend.Contractor, currentTurn)
        {
            _contractToExtend = contractToExtend;

            MinContractLength = contractToExtend.ExpirationTurn - currentTurn + 1;
        }

        public override void SignContract(int proposedContractLengthInTurns)
        {
            var wage = GetContractableExpectedWage(proposedContractLengthInTurns);
            var expirationTurn = _currentTurn + proposedContractLengthInTurns;

            _contractToExtend.Redefine(wage, expirationTurn);
        }
    }
}
