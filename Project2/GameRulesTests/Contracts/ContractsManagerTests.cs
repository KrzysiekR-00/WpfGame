using GameRules.Contracts;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Contracts
{
    [TestClass]
    public class ContractsManagerTests
    {
        private protected Employer _employer = null!;

        [TestInitialize]
        public void Initialize()
        {
            _employer = ContractsHelpers.CreateEmployer(0);
        }

        [TestMethod]
        [DataRow(1, new int[] { int.MinValue }, 0)]
        [DataRow(1, new int[] { int.MinValue, int.MaxValue }, 1)]
        [DataRow(1, new int[] { 0, 1, 2, 10 }, 2)]
        public void RemoveExpiredContracts_CreatedContracts_CorrectResult(int currentTurn, int[] contractsExpirationTurns, int expectedActiveContractsCount)
        {
            var contracts = ContractsHelpers.CreateContractsWithExpirationTurns(_employer, contractsExpirationTurns).ToArray();

            ContractsHelpers.AddContractsToEmployer(_employer, contracts);

            ContractsManager.RemoveExpiredContracts(_employer, currentTurn);

            Assert.AreEqual(expectedActiveContractsCount, _employer.Contracts.Length);
        }

        [TestMethod]
        public void AddContractToContractorAndEmployer_CreatedContract_ContractorHasReference()
        {
            var contract = ContractsHelpers.CreateContract(_employer, 0, 0);

            ContractsManager.AddContractToContractorAndEmployer(contract);

            Assert.AreEqual(contract, contract.Contractor.Contract);
        }

        [TestMethod]
        public void AddContractToContractorAndEmployer_CreatedContract_EmployerHasReference()
        {
            var contract = ContractsHelpers.CreateContract(_employer, 0, 0);

            ContractsManager.AddContractToContractorAndEmployer(contract);

            Assert.IsTrue(contract.Employer.Contracts.Contains(contract));
        }

        [TestMethod]
        public void RemoveContractFromContractorAndEmployer_CreatedContract_ContractorHasNullReference()
        {
            var contract = ContractsHelpers.CreateContract(_employer, 0, 0);

            ContractsManager.AddContractToContractorAndEmployer(contract);

            ContractsManager.RemoveContractFromContractorAndEmployer(contract);

            Assert.AreEqual(null, contract.Contractor.Contract);
        }

        [TestMethod]
        public void RemoveContractFromContractorAndEmployer_CreatedContract_EmployerHasNullReference()
        {
            var contract = ContractsHelpers.CreateContract(_employer, 0, 0);

            ContractsManager.AddContractToContractorAndEmployer(contract);

            ContractsManager.RemoveContractFromContractorAndEmployer(contract);

            Assert.IsTrue(!contract.Employer.Contracts.Contains(contract));
        }
    }
}
