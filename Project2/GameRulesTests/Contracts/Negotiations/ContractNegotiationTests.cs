using GameRules.Contracts;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Contracts.Negotiations
{
    [TestClass]
    public abstract class ContractNegotiationTests
    {
        private protected Employer _employer = null!;
        private protected IContractable _contractable = null!;
        private protected int _currentTurn;

        [TestInitialize]
        public void BaseInitialize()
        {
            _employer = ContractsHelpers.CreateEmployer(0);
            _contractable = CharactersHelpers.CreateElfCharacter(0);
            _currentTurn = 1;
        }
    }
}
