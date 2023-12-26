using GameRules.Teams;
using GameRules.Teams.Factories;

namespace GameRulesTests.Teams
{
    [TestClass]
    public class PlayerStartingTeamFactoryTests
    {
        private readonly Team _playerStartingTeam = new PlayerStartingTeamFactory().Create();

        [TestMethod]
        public void Create_PlayerStartingTeam_CorrectReputation()
        {
            Assert.AreEqual(PlayerStartingTeamFactory.TeamReputation, _playerStartingTeam.Employer.Reputation);
        }

        [TestMethod]
        public void Create_PlayerStartingTeam_CorrectContractsCount()
        {
            Assert.AreEqual(PlayerStartingTeamFactory.ContractsCount, _playerStartingTeam.Employer.Contracts.Length);
        }

        [TestMethod]
        public void Create_PlayerStartingTeam_CorrectAccountBalance()
        {
            Assert.AreEqual(PlayerStartingTeamFactory.AccountBalance, _playerStartingTeam.Account.Balance);
        }
    }
}
