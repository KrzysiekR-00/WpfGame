namespace GameRules.Contracts
{
    internal class ContractsManager
    {
        internal static void AddContractToContractorAndEmployer(Contract contract)
        {
            contract.Contractor.SetContract(contract);
            contract.Employer.AddContract(contract);
        }

        internal static void RemoveContractFromContractorAndEmployer(Contract contract)
        {
            contract.Contractor.SetContract(null);
            contract.Employer.RemoveContract(contract);
        }

        internal static void RemoveExpiredContracts(Employer employer, int currentTurn)
        {
            var expiredContracts = GetExpiredContracts(employer, currentTurn);

            Array.ForEach(expiredContracts, c => RemoveContractFromContractorAndEmployer(c));
        }

        private static Contract[] GetExpiredContracts(Employer employer, int currentTurn)
        {
            return employer.Contracts.Where(c => c.ExpirationTurn <= currentTurn).ToArray();
        }
    }
}
