using GameRules.Contracts;
using GameRules.Contracts.Negotiations;

namespace GameRulesTests.Contracts.Negotiations
{
    [TestClass]
    public class ExtensionNegotiationTests : ContractNegotiationTests
    {
        private Contract _contractToExtend = null!;

        [TestInitialize]
        public void Initialize()
        {
            int wage = 1;
            int length = _currentTurn + 1;
            _contractToExtend = new Contract(_employer, _contractable, wage, length);
        }

        [TestMethod]
        public void SignContract_LongerContract_RedefinedContractHasProperLength()
        {
            var negotiation = StartExtensionNegotiation();

            var existedContractLength = _contractToExtend.ExpirationTurn - _currentTurn;
            var lengthToPropose = existedContractLength + 1;
            negotiation.SignContract(lengthToPropose);

            var expectedExpirationTurn = _currentTurn + lengthToPropose;
            Assert.AreEqual(expectedExpirationTurn, _contractToExtend.ExpirationTurn);
        }

        [TestMethod]
        public void MinContractLength_ExtensionNegotiation_MinContractLengthIsGreaterThanExistedContractLength()
        {
            var negotiation = StartExtensionNegotiation();

            var existedContractLength = _contractToExtend.ExpirationTurn - _currentTurn;

            Assert.IsTrue(negotiation.MinContractLength > existedContractLength);
        }

        private ExtensionNegotiation StartExtensionNegotiation()
        {
            return new ExtensionNegotiation(_contractToExtend, _currentTurn);
        }
    }
}
