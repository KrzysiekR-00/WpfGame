namespace GameRules.Contracts.Negotiations
{
    public class NewContractNegotiation : ContractNegotiation
    {
        public NewContractNegotiation(Employer employer, IContractable contractable, int currentTurn) : base(employer, contractable, currentTurn)
        {

        }

        public override void SignContract(int proposedContractLengthInTurns)
        {
            var wage = GetContractableExpectedWage(proposedContractLengthInTurns);
            var expirationTurn = _currentTurn + proposedContractLengthInTurns;
            var contract = new Contract(_employer, _contractable, wage, expirationTurn);

            ContractsManager.AddContractToContractorAndEmployer(contract);
        }
    }
}
