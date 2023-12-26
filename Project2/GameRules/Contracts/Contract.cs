namespace GameRules.Contracts
{
    public class Contract
    {
        public Employer Employer { get; }
        public IContractable Contractor { get; }

        public float WagePerTurn { get; private set; }
        public int ExpirationTurn { get; private set; }

        internal Contract(Employer employer, IContractable contractor, float wagePerTurn, int expirationTurn)
        {
            Employer = employer;
            Contractor = contractor;
            WagePerTurn = wagePerTurn;
            ExpirationTurn = expirationTurn;
        }

        internal void Redefine(float newWagePerTurn, int newExpirationTurn)
        {
            WagePerTurn = newWagePerTurn;
            ExpirationTurn = newExpirationTurn;
        }
    }
}
