namespace GameRules.Contracts.Negotiations
{
    public class WageCalculator
    {
        private const int BaseWage = 300;
        private const float ModifierMinValue = 0.5f;
        private const float ModifierMaxValue = 5;
        private const int ExpectedContractLength = 15;

        public static float GetWage(int contractableExpectedReputation, float employerReputation, int proposedContractLength)
        {
            var reputationModifier = GetReputationModifier(contractableExpectedReputation, employerReputation);
            var contractLengthModifier = GetContractLengthModifier(proposedContractLength);
            return BaseWage * contractableExpectedReputation * reputationModifier * contractLengthModifier;
        }

        private static float GetReputationModifier(int contractableExpectedReputation, float employerReputation)
        {
            float modifier = contractableExpectedReputation / employerReputation;

            modifier = Math.Max(ModifierMinValue, modifier);
            modifier = Math.Min(ModifierMaxValue, modifier);

            return modifier;
        }

        private static float GetContractLengthModifier(int proposedContractLength)
        {
            float modifier = 1 + (((float)ExpectedContractLength - proposedContractLength) / 5);

            modifier = Math.Max(ModifierMinValue, modifier);
            modifier = Math.Min(ModifierMaxValue, modifier);

            return modifier;
        }
    }
}
