using GameRules.Finances;

namespace GameRulesTests.Finances
{
    [TestClass]
    public class AccountTests
    {
        private Account _account = null!;

        [TestInitialize]
        public void Initialize()
        {
            _account = new Account();
        }

        [TestMethod]
        public void OperationsHistory_AddOperation_CorrectHistoryLength()
        {
            _account.AddOperation(new Operation(OperationType.BattleReward, 0, 0));

            Assert.AreEqual(1, _account.OperationsHistory.Length);
        }

        [TestMethod]
        [DataRow(float.MinValue)]
        [DataRow(0)]
        [DataRow(float.MaxValue)]
        public void Balance_AddOperation_CorrectBalance(float operationAmount)
        {
            _account.AddOperation(new Operation(OperationType.BattleReward, 0, operationAmount));

            Assert.AreEqual(operationAmount, _account.Balance);
        }
    }
}
