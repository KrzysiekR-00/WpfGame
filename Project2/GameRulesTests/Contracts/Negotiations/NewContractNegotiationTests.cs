using GameRules.Contracts.Negotiations;

namespace GameRulesTests.Contracts.Negotiations
{
    [TestClass]
    public class NewContractNegotiationTests : ContractNegotiationTests
    {
        [TestMethod]
        public void SignContract_NewContract_EmployerHasContract()
        {
            var negotiation = StartNewContractNegotiation();

            negotiation.SignContract(1);

            Assert.IsTrue(_employer.Contracts.Any(c => c.Contractor == _contractable));
        }

        [TestMethod]
        public void SignContract_NewContract_ContractorHasContract()
        {
            var negotiation = StartNewContractNegotiation();

            negotiation.SignContract(1);

            Assert.IsTrue(_contractable.Contract?.Employer == _employer);
        }

        private protected NewContractNegotiation StartNewContractNegotiation()
        {
            return new NewContractNegotiation(_employer, _contractable, _currentTurn);
        }
    }
}
