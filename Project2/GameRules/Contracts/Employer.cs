using GameRules.Characters;

namespace GameRules.Contracts
{
    public class Employer
    {
        protected private readonly List<Contract> _contracts = new();

        public Contract[] Contracts => _contracts.ToArray();

        public float Reputation { get; private set; }

        internal float TotalWagesPerTurn => _contracts.Sum(c => c.WagePerTurn);

        internal Employer(int startReputation)
        {
            Reputation = startReputation;
        }
        
        internal void AddContract(Contract contract)
        {
            _contracts.Add(contract);
        }

        internal void RemoveContract(Contract contract)
        {
            _contracts.Remove(contract);
        }

        internal void RecalculateReputation()
        {
            var contractorsAverageLevel = (int)Math.Round(_contracts.Select(c => c.Contractor).OfType<Character>().Average(c => c.Level));

            Reputation = (Reputation + contractorsAverageLevel) / 2;
        }
    }
}
