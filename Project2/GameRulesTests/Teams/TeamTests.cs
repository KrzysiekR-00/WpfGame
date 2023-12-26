using GameRules.Teams;
using GameRules.Teams.Factories;

namespace GameRulesTests.Teams
{
    [TestClass]
    public class TeamTests
    {
        private readonly Team _team = new PlayerStartingTeamFactory().Create();

        [TestMethod]
        public void PayWages_PlayerStartingTeam_CorrectAccountBalance()
        {
            var expectedBalance = _team.Account.Balance - _team.Employer.TotalWagesPerTurn;

            _team.PayWages(1);

            Assert.AreEqual(expectedBalance, _team.Account.Balance);
        }

        [TestMethod]
        public void EarnBattleAward_Victory_CorrectAccountBalance()
        {
            var amount = 1;

            var expectedBalance = _team.Account.Balance + amount;

            _team.EarnBattleReward(1, amount);

            Assert.AreEqual(expectedBalance, _team.Account.Balance);
        }
    }
}
