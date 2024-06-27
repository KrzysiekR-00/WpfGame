using GameRules.Contracts;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Contracts
{
    [TestClass]
    public class EmployerTests
    {
        private protected Employer _employer = null!;

        [TestInitialize]
        public void Initialize()
        {
            _employer = ContractsHelpers.CreateEmployer(0);
        }

        [TestMethod]
        [DataRow(new float[] { 0 }, 0)]
        [DataRow(new float[] { 1 }, 1)]
        [DataRow(new float[] { 0, 1000, 2000 }, 3000)]
        public void TotalWagesPerTurn_CreatedContract_CorrectResult(float[] wages, float expectedExpensePerTurn)
        {
            var contracts = ContractsHelpers.CreateContractsWithWages(_employer, wages).ToArray();

            ContractsHelpers.AddContractsToEmployer(_employer, contracts);

            Assert.AreEqual(expectedExpensePerTurn, _employer.TotalWagesPerTurn);
        }

        [TestMethod]
        public void TotalWagesPerTurn_NoContracts_Zero()
        {
            Assert.AreEqual(0, _employer.TotalWagesPerTurn);
        }

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(10, 10, 10)]
        [DataRow(0, 10, 5)]
        public void RecalculateReputation_ReputationAfterCharacterAddition_CorrectResult(
            int startReputation,
            int employerToAddReputation,
            int expectedReputationAfterRecalculation)
        {
            var employer = ContractsHelpers.CreateEmployer(startReputation);

            var contractable = CharactersHelpers.CreateElfCharacter(employerToAddReputation);
            var contract = new Contract(employer, contractable, 0, 0);

            employer.AddContract(contract);

            employer.RecalculateReputation();

            Assert.AreEqual(expectedReputationAfterRecalculation, employer.Reputation);
        }
    }
}
