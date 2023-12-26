using GameRules.Combat;
using GameRules.Teams;
using GameRulesTests.TestsHelpers;

namespace GameRulesTests.Teams
{
    [TestClass]
    public class BattleAwardCalculatorTests
    {
        [TestMethod]
        public void GetAwardForTeam_UndecidedResult_HigherLevelEnemyGiveHigherAward()
        {
            var playerBattleSquad = BattlesHelpers.CreateBattleSquadWithOneMember(1);
            var battleResult = new BattleResult(playerBattleSquad);

            var higherLevelEnemy = BattlesHelpers.CreateBattleSquadWithOneMember(10);
            var higherLevelEnemyAward = BattleAwardCalculator.GetAwardForTeam(battleResult, higherLevelEnemy);

            var lowerLevelEnemy = BattlesHelpers.CreateBattleSquadWithOneMember(1);
            var lowerLevelEnemyAward = BattleAwardCalculator.GetAwardForTeam(battleResult, lowerLevelEnemy);

            Assert.IsTrue(higherLevelEnemyAward > lowerLevelEnemyAward);
        }
    }
}
